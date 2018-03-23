using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Settings.KEY_STRING);
            Console.WriteLine(Settings.KEY_INT);
            Console.WriteLine(Settings.KEY_BOOL);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}