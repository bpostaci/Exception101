using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Win32Api.Example
{
    class Program
    {
        const UInt32 DELETE = 0x00010000;
        const UInt32 READ_CONTROL = 0x00020000;
        const UInt32 SYNCHRONIZE = 0x00100000;
        const UInt32 WRITE_DAC = 0x00040000;
        const UInt32 WRITE_OWNER = 0x00080000;
        const UInt32 MUTEX_ALL_ACCESS = 0x1F0001;
        const UInt32 MUTEX_MODIFY_STATE = 0x0001;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenMutex(uint access, bool handle, string lpName);
        static void Main(string[] args)
        {
            Exception ex = new DivideByZeroException();
            
            PrintHR(Marshal.GetHRForException(ex));


            IntPtr hMutex = OpenMutex(SYNCHRONIZE, false, "TESTMUTEXT");

            var lastErrorCode = Marshal.GetLastWin32Error();
            
            var hResult = Marshal.GetHRForLastWin32Error();
            
            Console.WriteLine("Last Error Code:" +lastErrorCode);
            Console.WriteLine("HRESULT Dec:" + hResult);
            Console.WriteLine("HRESULT Hex:0x{0:X}", hResult);

            

            if (hMutex == IntPtr.Zero)
            {
                //DestroySharedMemory();
                throw new Win32Exception();
            }
        }

        static void PrintHR(int hResult)
        {
            Console.WriteLine("HRESULT Dec:" + hResult);
            Console.WriteLine("HRESULT Hex:0x{0:X}", hResult);
        }
    }
}
