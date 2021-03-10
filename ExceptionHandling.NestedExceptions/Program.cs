using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.NestedExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Program");

            try
            {
                MyThirdLevelFunction();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Catch in Main");
            }
            finally
            {
                Console.WriteLine("Finally in Main");
            }

            Console.WriteLine("End of Program");
            Console.ReadKey(false);

        }

        public static void MyFristLevelFunction()
        {
            try
            {
                MySecondLevelFunction();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Catch : My Frist Level Function: ");
            }
            finally
            {
                Console.WriteLine("Finally : My Frist Level Function: ");
            }
        }

        public static void MySecondLevelFunction()
        {
            try
            {
                MyThirdLevelFunction();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Catch : My Second Level Function: ");
            }
            finally
            {
                Console.WriteLine("Finally : My Second Level Function: ");
            }
        }

        public static void MyThirdLevelFunction()
        {
            Debugger.Break(); 

            throw new MindBlowingException();
        }
    }

    public class MindBlowingException : Exception
    {

    }

    
}
