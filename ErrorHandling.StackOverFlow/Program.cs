using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling.StackOverFlow
{
    class Program
    {
        public struct data
        {
            public int[] value { get; set; }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Stack Overflow Demo");
            
            RecursiveFunction(1000, "Lorem Ipsum Dolar Sitamet,Lorem Ipsum Dolar Sitamet,Lorem Ipsum Dolar Sitamet,Lorem Ipsum Dolar Sitamet");
            
            Console.WriteLine("You never see this");
        }

        static void RecursiveFunction(int iteration, string data)
        {
            string somedata = data;
            /*Some operations to manipulate the data */

            //Console.WriteLine("Iteration:" + iteration);
            if (iteration == 0) return;
            RecursiveFunction(iteration--, somedata);
        }
    }
}
