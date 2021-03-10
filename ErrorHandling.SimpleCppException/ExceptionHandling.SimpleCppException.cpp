// ErrorHandling.SimpleCppException.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdio.h>
#include <Windows.h>

int divide(int x, int y);

int main()
{
    std::cout << "Welcome to Exception Handling!\n";
    
    DebugBreak; 

    int x = 10;
    int b = 0;
    int result = divide(x, b);


    std::cout << result <<"Done\n";

}

__declspec(noinline) int divide(int x, int y)
{
    return x / y;
}
