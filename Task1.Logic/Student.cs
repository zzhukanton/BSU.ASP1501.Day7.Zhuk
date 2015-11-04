using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public class Student
    {
        public string Name { get; set; }

        public Student(string name, Timer timer)
        {
            Name = name;
            timer.TimerEvent += TimerMessage;
        }

        public void TimerMessage(object sender, EventArgs e)
        {
            Console.WriteLine("Student {0} gets a message", Name);
        }
    }
}
