using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingBasics2
{
    /// <summary>
    /// ERROR HANDLING
    /// TRY CATCH FINALLY
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Exception Handling Demo");

            try
            {
                FaultyCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }

            Console.WriteLine("GoodBye");
            Console.ReadKey(false);
        }

        static void FaultyCode()
        {
            int x = 0;
            int y = 15 / x;
        }

        static void AnotherFunction()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            finally
            {

            }

        }
    }
}
