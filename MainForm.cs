using RandomSens.Classes;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSens
{
    public partial class MainForm : Form
    {
        internal SensitivityCurve currentSensCurve;
        internal SensRandomizer SensRandomizer;
        internal HotkeyListener PauseListener;
        internal int curveType;
        internal double sensMean;
        internal double sensMax;
        internal double sensMin;
        internal double timestep;
        internal double curveTimestep;
        internal double spread;
        internal double smoothing;
        internal int curveLenght = 5;//default lenght is 5min
        internal int pause_Button;
        internal string pause_Button_Str;
        internal int stop_Button;
        internal string stop_Button_Str;
        internal bool isPaused = true;
        internal bool isStopped = true;
        internal bool isMinimized = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            StartRandomizer();
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseRandomizer();
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            StopRandomizer();
        }
        private void btn_Regen_Curve_Click(object sender, EventArgs e)
        {
            Create_Curve();
            SensRandomizer.sensitivityCurve = currentSensCurve;
        }
        private void btn_Interpolate_Curve_Click(object sender, EventArgs e)
        {
            InterpolateCurve();
        }
        private void cbox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            curveType = cb.SelectedIndex;
        }
        private void btn_Save_Defaults_Click(object sender, EventArgs e)
        {
            Save_Default_Settings();
        }
        private void btn_Load_Defaults_Click(object sender, EventArgs e)
        {
            Load_Default_Settings();
        }
        private void HotkeyListener_PauseKeyPressed(object sender, EventArgs e) //hadles the evenet by toggling the randomizer
        {
            Action toggleRandomizer = () => TogglePauseRandomizer(); //Invoke the toggle method from the main thread because it is
            this.Invoke(toggleRandomizer);                           //coming from a different thread that is only listening for keypresses
        }
        private void HotkeyListener_StopKeyPressed(object sender, EventArgs e) //hadles the evenet by toggling the randomizer
        {
            Action toggleRandomizer = () => ToggleStopRandomizer();
            this.Invoke(toggleRandomizer);
        }
        private void box_Pause_Toggle_DoubleClick(object sender, EventArgs e)
        {
            box_Pause_Toggle.Focus();
            box_Pause_Toggle.Clear();
            box_Pause_Toggle.ReadOnly = false;
            pause_Button = InterceptKey(); //use Interception to get the key press code
            PauseListener.pauseKey = pause_Button;
        }
        private void box_Stop_Toggle_DoubleClick(object sender, EventArgs e)
        {
            box_Stop_Toggle.Focus();
            box_Stop_Toggle.Clear();
            box_Stop_Toggle.ReadOnly = false;
            stop_Button = InterceptKey(); //use Interception to get the key press code
            PauseListener.stopKey = stop_Button;
        }
        private void box_Pause_Toggle_KeyDown(object sender, KeyEventArgs e)
        {
            pause_Button_Str = e.KeyData.ToString();
            box_Pause_Toggle.Text = e.KeyData.ToString();
            box_Pause_Toggle.ReadOnly = true;
            this.ActiveControl = null;
        }
        private void box_Stop_Toggle_KeyDown(object sender, KeyEventArgs e)
        {
            stop_Button_Str = e.KeyData.ToString();
            box_Stop_Toggle.Text = e.KeyData.ToString();
            box_Stop_Toggle.ReadOnly = true;
            this.ActiveControl = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Load_Default_Settings();
            Start_Pause_Listener(); //Start listening for the start/stop hotkey
            Create_Curve();
            SensRandomizer = new SensRandomizer(currentSensCurve);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                isMinimized = true;
            }
            if (WindowState == FormWindowState.Normal)
            {
                isMinimized = false;
                Update_UI(200);
            }
        }
        #region Validators
        private void box_Base_Sens_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_BaseSens.Text = sensMean.ToString();
            }
            else if (res < sensMin || res > sensMax || res <= 0)
            {
                e.Cancel = true;
                box_BaseSens.Text = sensMean.ToString();
            }
        }
        private void box_Max_Sens_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_Max_Sens.Text = sensMax.ToString();
            }
            else if (res < sensMean || res > 10)
            {
                e.Cancel = true;
                box_Max_Sens.Text = sensMax.ToString();
            }
        }
        private void box_Min_Sens_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_Min_Sens.Text = sensMin.ToString();
            }
            else if (res > sensMean || res <= 0)
            {
                e.Cancel = true;
                box_Min_Sens.Text = sensMin.ToString();
            }
        }
        private void box_Timestep_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_Timestep.Text = timestep.ToString();
            }
            else if (res <= 0)
            {
                e.Cancel = true;
                box_Timestep.Text = timestep.ToString();
            }
        }
        private void box_Spread_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_Spread.Text = spread.ToString();
            }
            else if (res <= 0 || res > 1)
            {
                e.Cancel = true;
                box_Spread.Text = spread.ToString();
            }
        }
        private void box_Curve_Timestep_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res) == false)
            {
                e.Cancel = true;//Cancel and restore value from properties
                box_Spread.Text = spread.ToString();
            }
            else if (res <= 0)
            {
                e.Cancel = true;
                box_Spread.Text = spread.ToString();
            }
        }
        private void box_Smoothing_Validating(object sender, CancelEventArgs e)
        {

        }
        private void box_Validated(object sender, EventArgs e)
        {
            bool changed = false;
            TextBox tb = (TextBox)sender;
            double val = Double.Parse(tb.Text);
            switch (tb.Name)
            {
                case "box_BaseSens":
                    if (sensMean == val)
                    {
                        break;
                    }
                    else
                    {
                        sensMean = val;
                        changed = true;
                        break;
                    }
                    break;
                case "box_Max_Sens":
                    if (sensMax == val)
                    {
                        break;
                    }
                    else
                    {
                        sensMax = val;
                        changed = true;
                        break;
                    }
                case "box_Min_Sens":
                    if (sensMin == val)
                    {
                        break;
                    }
                    else
                    {
                        sensMin = val;
                        changed = true;
                        break;
                    }
                case "box_Timestep":
                    if (timestep == val)
                    {
                        break;
                    }
                    else
                    {
                        timestep = val;
                        changed = true;
                        break;
                    }
                case "box_Curve_Timestep":
                    if (curveTimestep == val)
                    {
                        break;
                    }
                    else
                    {
                        curveTimestep = val;
                        changed = true;
                        break;
                    }
                case "box_Spread":
                    if (spread == val)
                    {
                        break;
                    }
                    else
                    {
                        spread = val;
                        changed = true;
                        break;
                    }
                case "box_Smoothing":
                    if (smoothing == val)
                    {
                        break;
                    }
                    else
                    {
                        smoothing = val;
                        changed = true;
                        break;
                    }
                default:
                    break;
            }
            if (changed)
            {
                Display_Settings();
            }
        }
        private void box_Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btn_Regen_Curve.Focus();
            }
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)&&(e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                //e.Handled = true;
            }
        }
        #endregion Validators



        private void Load_Default_Settings()
        {
            curveType = Properties.Settings.Default.curve_Type;
            sensMean = Properties.Settings.Default.base_Sens;
            sensMax = Properties.Settings.Default.max_Sens;
            sensMin = Properties.Settings.Default.min_Sens;
            timestep = Properties.Settings.Default.timestep;
            curveTimestep = Properties.Settings.Default.curve_Timestep;
            spread = Properties.Settings.Default.spread;
            smoothing = Properties.Settings.Default.smoothing;
            pause_Button = Properties.Settings.Default.pause_Button;
            pause_Button_Str = Properties.Settings.Default.pause_Button_Str;
            stop_Button = Properties.Settings.Default.stop_Button;
            stop_Button_Str = Properties.Settings.Default.stop_Button_Str;
            Display_Settings();
        }
        private void Save_Default_Settings()
        {
            Properties.Settings.Default.curve_Type = curveType;
            Properties.Settings.Default.base_Sens = sensMean;
            Properties.Settings.Default.max_Sens = sensMax;
            Properties.Settings.Default.min_Sens = sensMin;
            Properties.Settings.Default.timestep = timestep;
            Properties.Settings.Default.curve_Timestep = curveTimestep;
            Properties.Settings.Default.spread = spread;
            Properties.Settings.Default.smoothing = smoothing;
            Properties.Settings.Default.pause_Button = pause_Button;
            Properties.Settings.Default.pause_Button_Str = pause_Button_Str;
            Properties.Settings.Default.stop_Button = stop_Button;
            Properties.Settings.Default.stop_Button_Str = stop_Button_Str;
            Properties.Settings.Default.Save();
        }
        private void Display_Settings()
        {
            cbox_Type.SelectedIndex = curveType;
            box_BaseSens.Text = sensMean.ToString();
            box_Max_Sens.Text = sensMax.ToString();
            box_Max_Sens.Text = sensMax.ToString();
            box_Min_Sens.Text = sensMin.ToString();
            box_Timestep.Text = timestep.ToString();
            box_Curve_Timestep.Text = curveTimestep.ToString();
            box_Spread.Text = spread.ToString();
            box_Smoothing.Text = smoothing.ToString();
            box_Pause_Toggle.Text = pause_Button_Str;
            box_Stop_Toggle.Text = stop_Button_Str;
        }
        private void Enable_Settings() {
            box_BaseSens.Enabled = true;
            box_Max_Sens.Enabled = true;
            box_Min_Sens.Enabled = true;
            box_Smoothing.Enabled = true;
            box_Spread.Enabled = true;
            box_Timestep.Enabled = true;
            box_Curve_Timestep.Enabled = true;
            cbox_Type.Enabled = true;          
        }
        private void Disable_Settings() {
            box_BaseSens.Enabled = false;
            box_Max_Sens.Enabled = false;
            box_Min_Sens.Enabled = false;
            box_Smoothing.Enabled = false;
            box_Spread.Enabled = false;
            box_Timestep.Enabled = false;
            box_Curve_Timestep.Enabled = false;
            cbox_Type.Enabled = false;
        }
        private void Start_Pause_Listener()
        {
            PauseListener = new HotkeyListener(pause_Button, stop_Button);
            PauseListener.PauseKeyPressed += HotkeyListener_PauseKeyPressed; //subscribe the event to PauseListener_ToggleKeyPressed
            PauseListener.StopKeyPressed += HotkeyListener_StopKeyPressed;
            Task.Run(() =>
            {
                PauseListener.StartListener();
            });
        }
        private void Update_UI(int refreshRate)
        {
            Task.Run(() =>
            {
                while (isPaused == false && isStopped==false && isMinimized == false)
                {
                    Action updateCurrentSens = () => box_CurrentSens.Text = SensRandomizer.currentSens.ToString();
                    Action updateCompletion = () => box_Curve_Completion.Text = currentSensCurve.GetCompletion().ToString() + "%";
                    Action updateChart = () => sensCurveChart = currentSensCurve.GetChart(sensCurveChart);
                    Action updateChartCursorX = () => sensCurveChart.ChartAreas[0].CursorX.Position = currentSensCurve.GetCurrentPoint().timeStamp;
                    Action updateChartCursorY = () => sensCurveChart.ChartAreas[0].CursorY.Position = currentSensCurve.GetCurrentPoint().sensitivity;

                    box_CurrentSens.Invoke(updateCurrentSens);
                    box_Curve_Completion.Invoke(updateCompletion);
                    sensCurveChart.Invoke(updateChart);
                    sensCurveChart.Invoke(updateChartCursorX);
                    sensCurveChart.Invoke(updateChartCursorY);
                    System.Threading.Thread.Sleep(refreshRate);
                }
            });
        }
        private void Create_Curve()
        {
            //SensitivityCurve sensCurve = new AggressiveCurve(1,2,0.5,10,5);//default sensCurve init
            switch (cbox_Type.SelectedItem.ToString())
            {
                case "Aggressive Curve":
                    currentSensCurve = new AggressiveCurve(sensMean, sensMax, sensMin, timestep, curveTimestep, curveLenght);
                    break;
                case "Log Normal Curve":
                    currentSensCurve = new LogNormalCurve(sensMean, sensMax, sensMin, timestep, curveTimestep, curveLenght, spread);
                    break;
                case "Test Curve 1":
                    currentSensCurve = new TestCurve1(sensMean, sensMax, sensMin, timestep, curveTimestep, curveLenght);
                    break;
            }
            currentSensCurve.GenerateCurve();
            sensCurveChart = currentSensCurve.GetChart(sensCurveChart);
            sensCurveChart.Update();

            //InterpolateCurve();

            box_Std.Text = currentSensCurve.Stdev().ToString();
            box_Mean.Text = currentSensCurve.GetMean().ToString();
        }

        private void InterpolateCurve()
        {
            //currentSensCurve.InterpolateCurvePchip();
            currentSensCurve.InterpolateCurveNatural();
            //currentSensCurve.InterpolateCurveAkima();
            sensCurveChart = currentSensCurve.GetChart(sensCurveChart);
            sensCurveChart.Update();
        }

        private void StartRandomizer()
        {
            isPaused = false;
            isStopped = false;
            btn_Regen_Curve.Enabled = false;
            btn_Start.Enabled = false;
            btn_Pause.Enabled = true;
            btn_Stop.Enabled = true;
            Disable_Settings();
            Update_UI(200);//Start updating the UI and the graph every 200ms
            if (SensRandomizer.isPaused) //If the randomizer is paused - then resume
            {
                SensRandomizer.Resume();
            }
            else if(SensRandomizer.isStopped)//If its stopped then start it up
            {
                Task.Run(() =>
                {
                    SensRandomizer.Start();
                });
            }
        }
        private void PauseRandomizer()
        {
            isPaused = true;
            btn_Regen_Curve.Enabled = true;
            btn_Start.Enabled = true;
            btn_Pause.Enabled = false;
            Enable_Settings();
            SensRandomizer.Pause();
        }
        private void StopRandomizer()
        {
            isStopped = true;
            isPaused = false;
            btn_Regen_Curve.Enabled = true;
            btn_Start.Enabled = true;
            btn_Pause.Enabled = false;
            btn_Stop.Enabled = false;
            Enable_Settings();
            box_CurrentSens.Text = sensMean.ToString(); //Display the current sens as the base sens
            SensRandomizer.Stop();
        }
        private void TogglePauseRandomizer()
        {
            if (isPaused || isStopped)
            {
                StartRandomizer();
            }
            else
            {
                PauseRandomizer();
            }
            this.ActiveControl = null;
        }
        private void ToggleStopRandomizer()
        {
            if (isStopped)
            {
                StartRandomizer();
            }
            else
            {
                StopRandomizer();
            }
            this.ActiveControl = null;
        }
        private int InterceptKey()
        {
            int keyCode;
            IntPtr context;
            Interception.Stroke stroke = new Interception.Stroke();
            context = Interception.interception_create_context();
            int device;
            Interception.InterceptionPredicate del = Interception.interception_is_keyboard;
            Interception.interception_set_filter(
              context,
              del,
              (ushort)Interception.FilterKeyState.KeyDown);
            Interception.interception_receive(context, device = Interception.interception_wait(context), ref stroke, 1);
            Interception.KeyStroke kstroke = stroke;
            keyCode = kstroke.code;
            byte[] strokeBytes = Interception.getBytes(kstroke);
            Interception.interception_send(context, device, strokeBytes, 1);
            Interception.interception_destroy_context(context);
            return keyCode;
        }


    }
}
