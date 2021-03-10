using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.NestedExceptions2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Program");
            try
            {
                FuncLevel1();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error Occured:");
                Console.WriteLine("Error:" + ex.Message);
                Console.WriteLine("CallStack:\n" + ex.StackTrace);

            }
            Console.WriteLine("End of Program");
            Console.ReadKey(false);

        }

        static void FuncLevel1()
        {
            FuncLevel2();
        }

        private static void FuncLevel2()
        {
            FuncLevel3();
        }

        private static void FuncLevel3()
        {

            FuncLevel4();
        }

        private static void FuncLevel4()
        {
            throw new NotImplementedException();
        }
    }
}
