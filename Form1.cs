using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        internal SensitivityCurve currentSensCurve;
        internal int curveType;
        internal double sensMean;
        internal double sensMax;
        internal double sensMin;
        internal double timestep;
        internal double spread;
        internal double smoothing;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = ProcessPriorityClass.High;

            IntPtr context;
            int device;

            Interception.Stroke stroke = new Interception.Stroke();

            context = Interception.interception_create_context();

            Interception.InterceptionPredicate del = Interception.interception_is_mouse;
            Interception.interception_set_filter(
              context,
              del,
              (ushort)Interception.FilterMouseState.MouseMove);

            while (Interception.interception_receive(context, device = Interception.interception_wait(context), ref stroke, 1) > 0)
            {
                Interception.MouseStroke mstroke = stroke;
                mstroke.y = mstroke.y * -1;
                byte[] strokeBytes = Interception.getBytes(mstroke);
                Interception.interception_send(context, device, strokeBytes, 1);
            }
            Interception.interception_destroy_context(context);
        }
        private void btn_Regen_Curve_Click(object sender, EventArgs e)
        {
            //SensitivityCurve sensCurve = new AggressiveCurve(1,2,0.5,10,5);//default sensCurve init
            switch (cbox_Type.SelectedItem.ToString())
            {
                case "Aggressive Curve":
                    currentSensCurve = new AggressiveCurve(sensMean,sensMax,sensMin,timestep,5);
                    break;
                case "Log Normal Curve":
                    currentSensCurve = new LogNormalCurve(sensMean, sensMax, sensMin, timestep, 5, spread);
                    break;
            }
            currentSensCurve.GenerateCurve();
            currentSensCurve.InterpolateCurveAkima();
            sensCurveChart = currentSensCurve.GetChart(sensCurveChart, currentSensCurve.sensCurve);
        }
        private void cbox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Properties.Settings.Default.curve_Type = cb.SelectedIndex;
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
            else if ( res <= 0)
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
            Update_UI();
        }
        #endregion Validators
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Default_Settings();
        }
        #region Helper methods
        private void Load_Default_Settings()
        {
            curveType = Properties.Settings.Default.curve_Type;
            sensMean = Properties.Settings.Default.base_Sens;
            sensMax = Properties.Settings.Default.max_Sens;
            sensMin = Properties.Settings.Default.min_Sens;           
            timestep = Properties.Settings.Default.timestep;
            spread = Properties.Settings.Default.spread;
            smoothing = Properties.Settings.Default.smoothing;
            Update_UI();
        }
        private void Save_Default_Settings()
        {
            Properties.Settings.Default.curve_Type = curveType;
            Properties.Settings.Default.base_Sens = sensMean;
            Properties.Settings.Default.max_Sens = sensMax;
            Properties.Settings.Default.min_Sens = sensMin;
            Properties.Settings.Default.timestep = timestep;
            Properties.Settings.Default.spread = spread;
            Properties.Settings.Default.smoothing = smoothing;
            Properties.Settings.Default.Save();
        }
        private void Update_UI()
        {
            cbox_Type.SelectedIndex = curveType;
            box_BaseSens.Text = sensMean.ToString();
            box_Max_Sens.Text = sensMax.ToString();
            box_Max_Sens.Text = sensMax.ToString();
            box_Min_Sens.Text = sensMin.ToString();
            box_Timestep.Text = timestep.ToString();
            box_Spread.Text = spread.ToString();
            box_Smoothing.Text = smoothing.ToString();
        }
        #endregion Helper methods
        private void btn_Save_Defaults_Click(object sender, EventArgs e)
        {
            Save_Default_Settings();
        }
        private void btn_Load_Defaults_Click(object sender, EventArgs e)
        {
            Load_Default_Settings();
        }
    }
}
