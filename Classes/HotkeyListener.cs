using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSens.Classes
{
    class HotkeyListener
    {
        public bool isStopped = false; //internal Listener status
        public int pauseKey { get; set; }
        public int stopKey { get; set; }
        public event EventHandler PauseKeyPressed; //delegate
        public event EventHandler StopKeyPressed;
        public HotkeyListener(int pauseKey, int stopKey)
        {
            this.pauseKey = pauseKey;
            this.stopKey = stopKey;
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
                    OnPauseKeyPressed(); //If the registered key matches the pause key invoke the pausekey event
                }
                if (kstroke.code == stopKey)
                {
                    OnStopKeyPressed();
                }

            }
            Interception.interception_destroy_context(context);
        }

        private void OnPauseKeyPressed()
        {
            PauseKeyPressed.Invoke(this,EventArgs.Empty); //invoke the event with empty eventargs
        }
        private void OnStopKeyPressed()
        {
            StopKeyPressed.Invoke(this, EventArgs.Empty); //invoke the event with empty eventargs
        }
        public void StopListener()
        {
            isStopped = true;
        }
    }
}
