using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Interpolation;

namespace WindowsFormsApp1
{
    class SensitivityCurve
    {
        public List<SensitivityPoint> sensCurve { get; private set; }
        public List<SensitivityPoint> sensCurveSmoth { get; private set; }
        private Double sensMean;
        private Double sensMax;
        private Double sensMin;
        private Double timestep;
        private Double smoothing;
        private Double lenght; //lenght of the pre-generated curve in minutes

        public SensitivityCurve(Double sensMean, Double sensMax, Double sensMin, Double timestep, Double lenght)
        {
            this.sensMean = sensMean;
            this.sensMax = sensMax;
            this.sensMin = sensMin;
            this.timestep = timestep;
            this.lenght = lenght * 60; //lenght is converted to seconds
        }
        public void GenerateCurve()
        {
            //create the senseCurve, the start of the curve and start populating it with random values
            List<SensitivityPoint> sensCurve = new List<SensitivityPoint>();
            SensitivityPoint firstPoint = new SensitivityPoint(0, sensMean);
            sensCurve.Add(firstPoint);
            Random rnd = new Random();

            for (double timecode = timestep; timecode < this.lenght; timecode += timestep)
            {
                double sensDirection = rnd.NextDouble(); //create a random double to determine if sense is going to be faster or slower
                if (sensDirection >= 0.5)//sens will be faster
                {
                    double randomSens = sensMean + rnd.NextDouble() * (sensMax - sensMean); //generates a random value in the range of (basesens:maxsens)
                    SensitivityPoint sensPoint = new SensitivityPoint(timecode, randomSens);
                    sensCurve.Add(sensPoint);
                }
                else // sensDirection <0.5 -> sens will be slower
                {
                    double randomSens = sensMin + rnd.NextDouble() * (sensMean - sensMin);
                    SensitivityPoint sensPoint = new SensitivityPoint(timecode, randomSens);
                    sensCurve.Add(sensPoint);
                }
            }
            this.sensCurve = sensCurve;
        }
        public void InterpolateCurve() // generates a smoother version of the random curve
        {
            List<SensitivityPoint> smoothCurve = new List<SensitivityPoint>();
            // To do - make a smooth curve
            double[] timestamp = this.sensCurve.Select(sensCurve => sensCurve.timeStamp).ToArray();
            double[] randomsense = this.sensCurve.Select(sensCurve => sensCurve.sensitivity).ToArray();
            CubicSpline spline = CubicSpline.InterpolateAkima(timestamp, randomsense);
            for (double timecode = 0; timecode < this.lenght; timecode += 0.2)
            {
                SensitivityPoint sensPoint = new SensitivityPoint(timecode, spline.Interpolate(timecode));
                smoothCurve.Add(sensPoint);
            }
            this.sensCurveSmoth = smoothCurve;
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
    }
}
