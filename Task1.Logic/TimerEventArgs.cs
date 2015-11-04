using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public class TimerEventArgs: EventArgs
    {
        private int ticks;

        public TimerEventArgs(int ticks)
        {
            this.ticks = ticks;
        }

        public int Ticks
        {
            get { return ticks; }
        }
    }
}
