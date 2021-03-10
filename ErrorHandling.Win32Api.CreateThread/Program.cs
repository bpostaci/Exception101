using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorHandling.Win32Api.CreateThread
{
    class Program
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private unsafe static extern uint CreateThread(
        uint* lpThreadAttributes,
        uint dwStackSize,
        ThreadStart lpStartAddress,
        uint* lpParameter,
        uint dwCreationFlags,
        out uint lpThreadId);

        static void Main(string[] args)
        {
            StartThread(new ThreadStart(DoSomething), 16);
            Console.ReadLine();
        }

        unsafe private static void DoSomething()
        {
           while(true)
            {
                //Lets Generate a stack overflow.
                Span<int> numbers = stackalloc int[1024*16];
                
                Console.WriteLine("I am a new thread");
                Console.WriteLine("ThreadId:" + Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }

        unsafe static uint StartThread(ThreadStart ThreadFunc, int StackSize)
        {
            uint a = 0;
            uint* lpThrAtt = &a;
            uint i = 0;
            uint* lpParam = &i;
            uint lpThreadID = 0;

            uint dwHandle = CreateThread(null, (uint)StackSize, ThreadFunc, lpParam, 0, out lpThreadID);
            if (dwHandle == 0) throw new Exception("Unable to create thread!");
            return dwHandle;

        }
    }
}
