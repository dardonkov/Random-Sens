using System;
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
        private Double lenght; //lenght of the pre-generated curve in seconds
        
        public SensitivityCurve(Double sensMean, Double sensMax, Double sensMin, Double timestep, Double lenght)
        {
            this.sensMean = sensMean;
            this.sensMax = sensMax;
            this.sensMin = sensMin;
            this.timestep = timestep;
            this.lenght = lenght*60;
        }
        public List<SensitivityPoint> GenerateCurve()
        {
            //create the senseCurve, the start of the curve and start populating it with random values
            List<SensitivityPoint> sensCurve = new List<SensitivityPoint>;
            SensitivityPoint firstPoint = new SensitivityPoint(0, 0);
            sensCurve.Add(firstPoint);
            Random rnd = new Random();

            for (int i = 0; i < this.lenght; i++)
            {
                double sensDirection = rnd.NextDouble(); //create a random double to determine if sense is going to be faster or slower
                if (sensDirection >= 0.5)//sens will be faster
                {
                    double randomSens = 1 + (rnd.NextDouble() * (sensMax - 1));
                    SensitivityPoint sensPoint = new SensitivityPoint(i, randomSens);
                }
                else //sens will be slower
                {
                    double randomSens = rnd.NextDouble();
                }
                
            }
        }
    }
}
