using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ExceptionHandling.AsyncronousException
{
    class Program
    {
        static void Main(string[] args)
        {
            WatchDog.Interval = 1000;
            WatchDog.Elapsed += WatchDog_Elapsed;
            WatchDog.Start();

            AnotherExample();
            //try
            //{
            //    Task.Run(() => throw new Exception("Huston We have a problem"));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Where my exception has gone ??? ");
            //}

            Console.ReadKey(false);
        }

        static System.Timers.Timer WatchDog = new System.Timers.Timer();

        static int AM_I_HEALHTY = 0;
        static void AnotherExample()
        {
            

            try
            {
                Task.Run(() =>
                {

                    int iteration = 0;
                    while (1 < 2)
                    {
                        AM_I_HEALHTY = 0;
                        iteration++;
                        Console.WriteLine("Iteration:" + iteration);
                    /* Some Important Job to do */
                        if (iteration == 5) throw new Exception("Something bad happen Harry Potter!! My Secret Error code is 42");
                        AM_I_HEALHTY = 1;

                    /* End of Some Important Job to do */

                        Thread.Sleep(500);
                    }

                });
            }
            catch(Exception ex)
            {

            }
        }

        private static void WatchDog_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (AM_I_HEALHTY == 0)
            {
                Console.WriteLine("Houston we have a problem");
                Environment.Exit(1);
            }
            else
                Console.WriteLine("I am healty");
        }
    }
}
