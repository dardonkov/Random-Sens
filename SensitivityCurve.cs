﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SensitivityCurve
    {
        public List<SensitivityPoint> sensCurve { get; private set; }
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
            this.lenght = lenght*60; //lenght is converted to seconds
        }
        public List<SensitivityPoint> GenerateCurve()
        {
            //create the senseCurve, the start of the curve and start populating it with random values
            List<SensitivityPoint> sensCurve = new List<SensitivityPoint>();
            SensitivityPoint firstPoint = new SensitivityPoint(0, sensMean);
            sensCurve.Add(firstPoint);
            Random rnd = new Random();

            for (double timecode = 0; timecode < this.lenght; timecode+=timestep)
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
            return sensCurve;
        }
    }
}
