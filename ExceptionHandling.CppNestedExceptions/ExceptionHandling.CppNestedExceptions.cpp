// ExceptionHandling.CppNestedExceptions.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <exception>
#include <Windows.h>
#include <excpt.h>

void foo();
void bar();


int main()
{
    std::cout << "Hello World!\n";
    __try
    {
        foo();
    }
    __except (EXCEPTION_EXECUTE_HANDLER)
    {

    }
}

void foo()
{
    __try
    {
        bar();
    }
    __except (EXCEPTION_EXECUTE_HANDLER)
    {
        RUNTIME_FUNCTION f;
        f.BeginAddress;
        f.EndAddress;
        f.UnwindData;
        f.UnwindInfoAddress;
            
    }
}

void bar()
{
    __try
    {
        throw;
    }
    __except (EXCEPTION_EXECUTE_HANDLER)
    {

    }
}
