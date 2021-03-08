using System;
using System.Diagnostics;

namespace RandomSens.Classes
{
    class SensRandomizer
    {
        public bool isPaused { get; set; } = false;
        internal SensitivityCurve sensitivityCurve { get; private set; }
        internal double currentSens { get; private set; }
        internal double curveCompletion { get; private set; }
        

        public SensRandomizer(SensitivityCurve sensitivityCurve)
        {
            this.sensitivityCurve = sensitivityCurve;
        }
        public void Start()
        {
            using (Process p = Process.GetCurrentProcess())// Raise process priotity
                p.PriorityClass = ProcessPriorityClass.High;

            IntPtr context;
            Interception.Stroke stroke = new Interception.Stroke();
            context = Interception.interception_create_context();
            int device;
            Interception.InterceptionPredicate del = Interception.interception_is_mouse;
            Interception.interception_set_filter(
              context,
              del,
              (ushort)Interception.FilterMouseState.MouseMove);
            double magicX = 0;
            double magicY = 0;
            Stopwatch stopwatch = new Stopwatch();// Start a stopwatch to be used to advance the curve

            //int sw = 0; // Rough stopwatch in ms
            while (Interception.interception_receive(context, device = Interception.interception_wait(context), ref stroke, 1) > 0)//Start listening for mouse strokes
            {
                //sw += 20; // Every cycle takes roughly 20ms so we add 20ms
                stopwatch.Start();
                if (sensitivityCurve.isFinished)
                {
                    break;
                }
                Interception.MouseStroke mstroke = stroke;
                SensitivityPoint currentPoint = sensitivityCurve.GetCurrentPoint();

                double x = mstroke.x * currentPoint.sensitivity + magicX;
                double y = mstroke.y * currentPoint.sensitivity + magicY;

                magicX = x - Math.Floor(x);
                magicY = y - Math.Floor(y);

                mstroke.x = (int)Math.Floor(x);
                mstroke.y = (int)Math.Floor(y);

                byte[] strokeBytes = Interception.getBytes(mstroke);
                Interception.interception_send(context, device, strokeBytes, 1);
                if (isPaused)
                {
                    //sw -= 20;
                    stopwatch.Reset();
                }
                if (stopwatch.ElapsedMilliseconds > sensitivityCurve.timestep * 1000) //when sw equals timestep in ms we advance the cursor
                {
                    currentSens = currentPoint.sensitivity;
                    sensitivityCurve.AdvanceCursor();
                    //sw = 0; // Reset the sw
                    stopwatch.Restart();
                }
            }
            Interception.interception_destroy_context(context);
            if (isPaused == false)
            {
                sensitivityCurve.RegenerateCurve();
                sensitivityCurve.InterpolateCurveAkima();
                Start();
            }
        }
        internal void Pause()
        {
            isPaused = true;
        }
        internal void Resume()
        {
            isPaused = false;
        }
    }
}
