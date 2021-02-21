﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class AgressiveCurve : SensitivityCurve
    {
        public List<SensitivityPoint> curve { get; private set; }
        public List<SensitivityPoint> curveSmoth { get; private set; }
        public AgressiveCurve(Double sensMean, Double sensMax, Double sensMin, Double timestep, Double lenght)
        {
            base.sensMean = sensMean;
            base.sensMax = sensMax;
            base.sensMin = sensMin;
            base.timestep = timestep;
            base.lenght = lenght * 60; //lenght is converted to seconds
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
            SensitivityPoint finalSensPoint = new SensitivityPoint(timestep + this.lenght, 0);//Make sure the curve ends at base sens
            sensCurve.Add(finalSensPoint);
            this.curve = sensCurve;
        }
    }
}
