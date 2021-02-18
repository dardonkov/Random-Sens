using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
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
            SensitivityCurve sensCurve = new SensitivityCurve(1,2,0.5,10,5);
            sensCurve.GenerateCurveType1();
            sensCurve.InterpolateCurveAkima();
            sensCurveChart = sensCurve.GetChart(sensCurveChart, sensCurve.sensCurveSmoth);
        }
    }
}
