using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Exception Handling Demo");

            FaultyCode(); 

            Console.WriteLine("GoodBye");
            Console.ReadKey(false);

        }

        static void FaultyCode()
        {
            throw new DivideByZeroException();
         //   int x = 0;
           // int y = 15 / x; 
        }
    }
}
