

/* ITS WORKS ONLY 32-BIT */

#include <iostream>
#include <Windows.h>


EXCEPTION_DISPOSITION _MyException_Handler(
    struct _EXCEPTION_RECORD* ExceptionRecord,
    void* EstablisherFrame,
    struct _CONTEXT* ContextRecord,
    void* DispatcherContext)
{
    printf("An exception occured at address 0x%p, with ExceptionCode = 0x%08x!\n",
        ExceptionRecord->ExceptionAddress,
        ExceptionRecord->ExceptionCode);

    return ExceptionContinueSearch;
}

const int LetsCreateAccessViolation = 0;

void SomeFaultyCode()
{
    std::cout << "Hello World!\n";

    //Register our exception handler
    NT_TIB* TIB = (NT_TIB*)NtCurrentTeb();
    EXCEPTION_REGISTRATION_RECORD Registration;
    Registration.Handler = (PEXCEPTION_ROUTINE)_MyException_Handler;
    Registration.Next = TIB->ExceptionList;
    TIB->ExceptionList = &Registration;

    //Protected Code Here;
    printf("Before Exception");

    const_cast<int&>(LetsCreateAccessViolation) = 1;

    printf("After Exception");


    //Remove Registration;
    TIB->ExceptionList = TIB->ExceptionList->Next;
    
}

int main()
{
    
        SomeFaultyCode();
   
}

