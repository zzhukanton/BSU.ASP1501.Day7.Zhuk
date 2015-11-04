using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public class Timer
    {
        public event EventHandler<TimerEventArgs> TimerEvent;

        protected virtual void OnTimerEvent(TimerEventArgs e)
        {
            Thread.Sleep(e.Ticks);

            EventHandler<TimerEventArgs> timer = TimerEvent;

            if (timer != null)
                timer(this, e);
        }

        public void ImitateTimer(int ticks)
        {
            OnTimerEvent(new TimerEventArgs(ticks));
        }
    }
}
