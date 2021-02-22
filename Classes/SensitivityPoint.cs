using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SensitivityPoint
    {
        public double timeStamp { get; set; }
        public double sensitivity { get; set; }
        public SensitivityPoint(double timeStamp, double sensitivity)
        {
            this.timeStamp = timeStamp;
            this.sensitivity = sensitivity;
        }
    }
}
