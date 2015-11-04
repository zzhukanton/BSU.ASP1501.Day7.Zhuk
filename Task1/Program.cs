using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Logic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            Student s = new Student("Anton", t);

            t.ImitateTimer(2000);
            Console.ReadLine();
        }
    }
}
