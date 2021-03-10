// ErrorHandling.CppExample.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <stdio.h>
#include <Windows.h>
#include <exception>

class TestClass
{
public:
    ~TestClass()
    {
        printf("Destroying TestClass!\r\n");
    }
};

__declspec(noinline) void TestCPPEX()
{
#ifdef CPPEX
    printf("Throwing C++ exception\r\n");
    throw std::exception("");
#else
    printf("Triggering SEH exception\r\n");
    volatile int* pInt = 0x00000000;
    *pInt = 20;

    /*
    __asm
    {
        mov eax, 0 // Zero out EAX
        mov[eax], 1 // Write to EAX to deliberately cause a fault
    }
    */

#endif
}

__declspec(noinline) void TestExceptions()
{
    TestClass d;
    TestCPPEX();
}

int main()
{

    __try
    {
        

        TestExceptions();
    }
    __except (EXCEPTION_EXECUTE_HANDLER)
    {
        printf("Executing SEH __except block\r\n");
    }

    return 0;
}

