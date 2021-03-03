using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    class PauseListener
    {
        public bool isPaused { get; set; } //Public pause toggle
        public bool isStopped = false; //internal Listener status
        private readonly int pauseKey;
        public PauseListener(int pauseKey)
        {
            this.pauseKey = pauseKey;
        }
        public void StartListener()
        {
            isStopped = false;
            IntPtr context;
            Interception.Stroke stroke = new Interception.Stroke();
            context = Interception.interception_create_context();
            int device;
            Interception.InterceptionPredicate del = Interception.interception_is_keyboard;
            Interception.interception_set_filter(
              context,
              del,
              (ushort)Interception.FilterKeyState.KeyDown);
            while (!isStopped) //Start listening for keyboard strokes
            {
                Interception.interception_receive(context, device = Interception.interception_wait(context), ref stroke, 1);
                Interception.KeyStroke kstroke = stroke;
                byte[] strokeBytes = Interception.getBytes(kstroke);
                Interception.interception_send(context, device, strokeBytes, 1);
                if (kstroke.code == pauseKey)
                {
                    TogglePause();
                }
            }
            Interception.interception_destroy_context(context);
        }
        public void StopListener()
        {
            isStopped = true;
        }
        private void TogglePause()
        {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }
    }
}
