using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExceptionHandling.AsyncronousExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            Thread thread = new Thread(new ThreadStart(DoSomeJob));
            thread.Start();

            /*wait a little bit and abord the thread */
            Thread.Sleep(1000);
            thread.Abort(); 

        }

        private static void DoSomeJob()
        {
            try
            {
                /*doing something important*/
            }
            finally
            {
                // commiting transaction 
            }

            while(1<2)
                Thread.Sleep(1000);
        }
    }
}
