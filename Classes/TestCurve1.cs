﻿using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Distributions;

namespace RandomSens
{
    class TestCurve1 : SensitivityCurve
    {
        public TestCurve1(Double sensMean, Double sensMax, Double sensMin, Double timestep, Double curveTimestep, Double lenght)
        {
            base.sensMean = sensMean;
            base.sensMax = sensMax;
            base.sensMin = sensMin;
            base.curveTimestep = curveTimestep;
            base.timestep = timestep;
            base.lenght = lenght * 60; //lenght is converted to seconds
        }
        internal override void GenerateCurve()
        {
            //create the senseCurve, the start of the curve and start populating it with random values
            List<SensitivityPoint> sensCurve = new List<SensitivityPoint>();
            SensitivityPoint firstPoint = new SensitivityPoint(0, sensMean);
            sensCurve.Add(firstPoint);
            var seededRandom = new SystemRandomSource(42);//creates a random source with the seed "42"
            for (double timecode = curveTimestep; timecode < this.lenght; timecode += curveTimestep)
            {
                double sensDirection = seededRandom.NextDouble(); //create a random double to determine if sense is going to be faster or slower
                if (sensDirection >= 0.5)//sens will be faster
                {
                    double randomSens = sensMean + seededRandom.NextDouble() * (sensMax - sensMean); //generates a random value in the range of (basesens:maxsens)
                    SensitivityPoint sensPoint = new SensitivityPoint(timecode, randomSens);
                    sensCurve.Add(sensPoint);
                }
                else // sensDirection <0.5 -> sens will be slower
                {
                    double randomSens = sensMin + seededRandom.NextDouble() * (sensMean - sensMin);
                    SensitivityPoint sensPoint = new SensitivityPoint(timecode, randomSens);
                    sensCurve.Add(sensPoint);
                }
            }
            SensitivityPoint finalSensPoint = new SensitivityPoint(this.lenght, 1);//Make sure the curve ends at base sens
            sensCurve.Add(finalSensPoint);
            base.sensCurve = sensCurve;
        }
    }
}
