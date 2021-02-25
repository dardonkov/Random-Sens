using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Classes
{
    class LogNormalCurve : SensitivityCurve
    {
        public double sigma { get; private set; }
        public LogNormalCurve(Double sensMean, Double sensMax, Double sensMin, Double timestep, Double curveTimestep, Double lenght, double sigma)
        {
            base.sensMean = sensMean;
            base.sensMax = sensMax;
            base.sensMin = sensMin;
            base.timestep = timestep;
            base.curveTimestep = curveTimestep;
            base.lenght = lenght * 60; //lenght is converted to seconds
            this.sigma = sigma;
        }
        internal override void GenerateCurve()
        {
            //create the senseCurve, the start of the curve and start populating it with random values
            List<SensitivityPoint> sensCurve = new List<SensitivityPoint>();
            SensitivityPoint firstPoint = new SensitivityPoint(0, sensMean);
            sensCurve.Add(firstPoint);
            //Random rnd = SystemRandomSource.Default;
            var logNormal = new LogNormal(0, sigma);

            for (double timecode = curveTimestep; timecode < this.lenght; timecode += curveTimestep)
            {
                double randomSens;
                do //keep trying to create a random sens within the set min/max boundries
                {
                    randomSens = logNormal.Sample();
                } while (randomSens > sensMax || randomSens < sensMin);
                SensitivityPoint sensPoint = new SensitivityPoint(timecode, randomSens);
                sensCurve.Add(sensPoint);
            }
            SensitivityPoint finalSensPoint = new SensitivityPoint(this.lenght, 1);//Make sure the curve ends at base sens
            sensCurve.Add(finalSensPoint);
            base.sensCurve = sensCurve;
        }
    }
}
