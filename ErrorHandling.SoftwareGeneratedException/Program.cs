using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.SoftwareGeneratedException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo Software Generated Exception");

            
            ValidateNumber("A123456789");

            ValidateNumber("123456789");
        }
        /// <summary>
        /// Function checks the numbers if starts with "A" a valid number is A123456789
        /// </summary>
        /// <param name="ssn"></param>
        static void ValidateNumber(string ssn)
        {
            if (!ssn.StartsWith("A"))
                throw new ArgumentException("Invalid SSN Number");
            if(ssn.Length < 10)
                throw new ArgumentException("Invalid SSN Number");

            Console.WriteLine("Number Valid:" + ssn);
        }
    }
}
