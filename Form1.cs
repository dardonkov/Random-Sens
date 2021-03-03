using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        internal SensitivityCurve currentSensCurve;
        internal SensRandomizer SensRandomizer;
        internal PauseListener PauseListener;
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
        internal bool isPaused = true;
        internal bool isMinimized = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            isPaused = false;
            PauseListener.isPaused = isPaused;//synchonize the listener with local pause status var
            btn_Regen_Curve.Enabled = false;
            btn_Start.Enabled = false;
            StartRandomizer();
            Update_UI(200);
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            PauseListener.isPaused = isPaused;
            btn_Regen_Curve.Enabled = true;
            btn_Start.Enabled = true;
            Task.Run(() =>
            {
                SensRandomizer.Pause();
            });
        }
        private void btn_Regen_Curve_Click(object sender, EventArgs e)
        {
            Create_Curve();
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
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Default_Settings();
            Update_Pause_Status(200); //Start listening for the start/stop hotkey
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
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
        private void box_Smoothing_Validating(object sender, CancelEventArgs e)
        {

        }
        private void box_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            double val = Double.Parse(tb.Text);
            switch (tb.Name)
            {
                case "box_BaseSens":
                    sensMean = val;
                    break;
                case "box_Max_Sens":
                    sensMax = val;
                    break;
                case "box_Min_Sens":
                    sensMin = val;
                    break;
                case "box_Timestep":
                    timestep = val;
                    break;
                case "box_Spread":
                    spread = val;
                    break;
                case "box_Smoothing":
                    smoothing = val;
                    break;
                default:
                    break;
            }
            Display_Settings();
        }
        #endregion Validators
        #region Helper methods
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
            }
            currentSensCurve.GenerateCurve();
            currentSensCurve.InterpolateCurveAkima();
            sensCurveChart = currentSensCurve.GetChart(sensCurveChart);
            sensCurveChart.Update();
            box_Std.Text = currentSensCurve.Stdev().ToString();
            box_Mean.Text = currentSensCurve.GetMean().ToString();
        }

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
        }
        private void Update_Pause_Status(int refreshRate)
        {
            if (PauseListener == null)
            {
                PauseListener = new PauseListener(pause_Button);
                PauseListener.isPaused = isPaused;
            }
            Task.Run(() =>
            {
                PauseListener.StartListener();
            });
            Task.Run(() =>
            {
                Action pause = () => btn_Pause.PerformClick();
                Action start = () => btn_Start.PerformClick();
                while (!PauseListener.isStopped)
                {
                    if (PauseListener.isPaused && !isPaused)
                    {
                        btn_Pause.Invoke(pause);
                    }
                    if (!PauseListener.isPaused && isPaused)
                    {
                        btn_Start.Invoke(start);
                    }
                    System.Threading.Thread.Sleep(refreshRate);
                }
                PauseListener.StopListener();
            });
        }

        private void Update_UI(int refreshRate)
        {
            Task.Run(() =>
            {
                while (isPaused == false && isMinimized == false)
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

        private void StartRandomizer()
        {
            if (currentSensCurve == null)
            {
                Create_Curve();
            }
            SensRandomizer = new SensRandomizer(currentSensCurve);
            Task.Run(() =>
            {
                SensRandomizer.Start();
            });
        }
        #endregion Helper methods

        private void box_Pause_Toggle_DoubleClick(object sender, EventArgs e)
        {
            PauseListener.StopListener(); //Stop and properly dispose the current start/stop hotkey listener
            box_Pause_Toggle.Focus();
            box_Pause_Toggle.Clear();
            box_Pause_Toggle.ReadOnly = false;
            pause_Button = InterceptKey(); //use Interception to get the key press code
            Update_Pause_Status(200); //Recreate the start/stop hotkey listener
        }
        private void box_Pause_Toggle_KeyDown(object sender, KeyEventArgs e)
        {
            pause_Button_Str = e.KeyData.ToString();
            box_Pause_Toggle.Text = e.KeyData.ToString();
            box_Pause_Toggle.ReadOnly = true;
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
