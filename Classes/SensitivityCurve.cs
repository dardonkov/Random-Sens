﻿using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace RandomSens
{
    abstract class SensitivityCurve
    {
        public List<SensitivityPoint> sensCurve { get; set; }
        internal bool isFinished = false;
        public Double sensMean { get; internal set; }
        public Double sensMax { get; internal set; }
        public Double sensMin { get; internal set; }
        public Double timestep { get; internal set; }
        public Double curveTimestep { get; internal set; }
        public Double lenght { get; internal set; } //lenght of the pre-generated curve in minutes       
        internal int cursor = 0;

        internal abstract void GenerateCurve();
        public void InterpolateCurveAkima() // generates a smoother version of the random curve
        {
            List<SensitivityPoint> smoothCurve = new List<SensitivityPoint>();
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
        public void InterpolateCurveNatural()
        {
            List<SensitivityPoint> smoothCurve = new List<SensitivityPoint>();
            double[] timestamp = sensCurve.Select(sensCurve => sensCurve.timeStamp).ToArray();
            double[] randomsense = sensCurve.Select(sensCurve => sensCurve.sensitivity).ToArray();
            CubicSpline spline = CubicSpline.InterpolateNatural (timestamp, randomsense);
            for (double timecode = 0; timecode < this.lenght; timecode += timestep)
            {
                SensitivityPoint sensPoint = new SensitivityPoint(timecode, spline.Interpolate(timecode));
                smoothCurve.Add(sensPoint);
            }
            sensCurve = smoothCurve;
        }
        public void InterpolateCurvePchip()
        {
            List<SensitivityPoint> smoothCurve = new List<SensitivityPoint>();
            double[] timestamp = sensCurve.Select(sensCurve => sensCurve.timeStamp).ToArray();
            double[] randomsense = sensCurve.Select(sensCurve => sensCurve.sensitivity).ToArray();
            CubicSpline spline = CubicSpline.InterpolatePchip(timestamp, randomsense);
            for (double timecode = 0; timecode < this.lenght; timecode += timestep)
            {
                SensitivityPoint sensPoint = new SensitivityPoint(timecode, spline.Interpolate(timecode));
                smoothCurve.Add(sensPoint);
            }
            sensCurve = smoothCurve;
        }
        public Chart GetChart(Chart sensChart) //Modifies the provided chart object to create a sensitivity over time chart
        {
            sensChart.Series.Clear(); // Clear any existing series and add the sens points
            var sens = new Series("Sensitivity");
            foreach (var point in sensCurve)
            {
                sens.Points.AddXY(point.timeStamp, point.sensitivity);
            }
            sens.ChartType = SeriesChartType.Line;
            sensChart.Series.Add(sens);
            // Format the chart to conform the data
            sensChart.ChartAreas[0].AxisY.Minimum = sensMin - 0.1;
            sensChart.ChartAreas[0].AxisY.Maximum = sensMax + 0.1;
            //sensChart.ChartAreas[0].AxisX.RoundAxisValues();
            return sensChart;
        }
        public double GetCompletion()
        {
            double completionP = (100 * cursor) / sensCurve.Count();
            return completionP;
            //return Math.Round(completionP,2);
        }
        internal SensitivityPoint GetCurrentPoint()
        {
            return sensCurve[cursor];
        }
        internal virtual double GetMean()
        {
            double mean = sensCurve.Select(sensCurve => sensCurve.sensitivity).Average();
            return Math.Round(mean, 5);
        }
        internal virtual double Stdev()
        {
            List<double> values = sensCurve.Select(sensCurve => sensCurve.sensitivity).ToList();
            double mean = GetMean();
            double sum = values.Sum(d => Math.Pow(d - mean, 2));
            double stdev = Math.Sqrt((sum) / (values.Count() - 1));
            return Math.Round(stdev, 5);
        }
        internal void AdvanceCursor()
        {
            cursor++;
            if (cursor == sensCurve.Count)// When the cursor reaches the end of the curve mark it as finished
            {
                isFinished = true;
            }
        }
        internal void RegenerateCurve()
        {
            GenerateCurve(); //Generate curve again and reset cursor
            cursor = 0;
            isFinished = false;
        }
    }
}
