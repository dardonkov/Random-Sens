using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Interpolation;

namespace WindowsFormsApp1
{
    abstract class  SensitivityCurve
    {
        public List<SensitivityPoint> sensCurve { get; set; }
        public bool isFinished = false;
        protected Double sensMean;
        protected Double sensMax;
        protected Double sensMin;
        protected Double timestep;
        protected Double curveTimestep;
        protected Double lenght; //lenght of the pre-generated curve in minutes       
        protected int cursor = 0;
        
        internal abstract void GenerateCurve();
        public void InterpolateCurveAkima() // generates a smoother version of the random curve
        {
            List<SensitivityPoint> smoothCurve = new List<SensitivityPoint>();
            // To do - make a smooth curve
            double[] timestamp = sensCurve.Select(sensCurve => sensCurve.timeStamp).ToArray();
            double[] randomsense = sensCurve.Select(sensCurve => sensCurve.sensitivity).ToArray();
            CubicSpline spline = CubicSpline.InterpolateAkima(timestamp, randomsense);
            for (double timecode = 0; timecode < this.lenght; timecode += timestep)
            {
                SensitivityPoint sensPoint = new SensitivityPoint(timecode, spline.Interpolate(timecode));
                smoothCurve.Add(sensPoint);
            }
            sensCurve = smoothCurve;
        }
        public Chart GetChart(Chart sensChart, List<SensitivityPoint> sensitivityPoints) //Modifies the provided chart object to create a sensitivity over time chart
        {
            sensChart.Series.Clear(); // Clear any existing series and add the sens points
            var sens = new Series("Sensitivity");
            foreach (var point in sensitivityPoints)
            {
                sens.Points.AddXY(point.timeStamp, point.sensitivity);
            }
            sens.ChartType = SeriesChartType.Line;
            sensChart.Series.Add(sens);
            // Format the chart to conform the data
            sensChart.ChartAreas[0].AxisY.Minimum = sensMin;
            sensChart.ChartAreas[0].AxisY.Maximum = sensMax;
            //sensChart.ChartAreas[0].AxisX.RoundAxisValues();
            return sensChart;
        }  
        internal SensitivityPoint GetCurrentPoint()
        {
            return sensCurve[cursor];
        }
        internal void AdvanceCursor()
        {
            cursor++;
            if (cursor==sensCurve.Count)// When the cursor reaches the end of the curve mark it as finished
            {
                isFinished = true;
            }
        }
    }
}
