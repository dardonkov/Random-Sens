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
        private SensitivityCurve currentSensCurve;
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
            double sensMean = Properties.Settings.Default.base_Sens;
            double sensMax = Properties.Settings.Default.max_Sens;
            double sensMin = Properties.Settings.Default.min_Sens;
            double timestep = Properties.Settings.Default.timestep;
            double spread = Properties.Settings.Default.spread;
            double smoothing = Properties.Settings.Default.smoothing;
            SensitivityCurve sensCurve = new AggressiveCurve(1,2,0.5,10,5);//default sensCurve init
            switch (cbox_Type.SelectedItem)
            {
                case "Aggressive Curve":
                    sensCurve = new AggressiveCurve(sensMean,sensMax,sensMin,timestep,5);
                    break;
                case "LogNormal Curve":
                    sensCurve = new LogNormalCurve(sensMean, sensMax, sensMin, timestep, 5, spread);
                    break;
            }
            sensCurve.GenerateCurve();
            sensCurve.InterpolateCurveAkima();
            sensCurveChart = sensCurve.GetChart(sensCurveChart, sensCurve.sensCurve);
        }
        private void box_double_Validating(object sender, CancelEventArgs e)
        {
            double res;
            TextBox tb = (TextBox)sender;
            if (Double.TryParse(tb.Text, out res))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                //Restore previous value
                switch (tb.Name)
                {
                    case "box_BaseSens":
                        box_BaseSens.Text = Properties.Settings.Default.base_Sens.ToString();
                        break;
                    case "box_Max_Sens":
                        box_Max_Sens.Text = Properties.Settings.Default.max_Sens.ToString();
                        break;
                    case "box_Min_Sens":
                        box_Min_Sens.Text = Properties.Settings.Default.min_Sens.ToString();
                        break;
                    case "box_Timestep":
                        box_Timestep.Text = Properties.Settings.Default.timestep.ToString();
                        break;
                    case "box_Spread":
                        box_Spread.Text = Properties.Settings.Default.spread.ToString();
                        break;
                    case "box_Smoothing":
                        box_Smoothing.Text = Properties.Settings.Default.smoothing.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        private void cbox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Properties.Settings.Default.curve_Type = cb.SelectedIndex;
        }
        private void box_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            double val = Double.Parse(tb.Text);
            switch (tb.Name)
            {
                case "box_BaseSens":
                    Properties.Settings.Default.base_Sens = val;
                    break;
                case "box_Max_Sens":
                    Properties.Settings.Default.max_Sens = val;
                    break;
                case "box_Min_Sens":
                    Properties.Settings.Default.min_Sens = val;
                    break;
                case "box_Timestep":
                    Properties.Settings.Default.timestep = val;
                    break;
                case "box_Spread":
                    Properties.Settings.Default.spread = val;
                    break;
                case "box_Smoothing":
                    Properties.Settings.Default.smoothing = val;
                    break;
                default:
                    break;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Settings();
        }
        private void Load_Settings()
        {
            cbox_Type.SelectedIndex = Properties.Settings.Default.curve_Type;
            box_BaseSens.Text = Properties.Settings.Default.base_Sens.ToString();
            box_Max_Sens.Text = Properties.Settings.Default.max_Sens.ToString();
            box_Min_Sens.Text = Properties.Settings.Default.min_Sens.ToString();
            box_Timestep.Text = Properties.Settings.Default.timestep.ToString();
            box_Spread.Text = Properties.Settings.Default.spread.ToString();
            box_Smoothing.Text = Properties.Settings.Default.smoothing.ToString();
        }
    }
}
