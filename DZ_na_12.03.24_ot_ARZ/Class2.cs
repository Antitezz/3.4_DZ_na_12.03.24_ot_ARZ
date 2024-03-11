using System;
interface  : InterfaceDimensional
{
    void PublicInputArray();
    void PublicRandomArray();
    void PublicCreateArray(bool consoleValues = false);
    void MiddleValue();
    void CreateAgain(bool consoleValues = false);
}

interface InterfaceDimensional
{
    void Print();
}

interface InterfaceOneDimensional
{
    void GetRidofValue();
    void NonRepeat();
}

interface InterfaceTwoDimensional
{
    int GetDeterminant();
}

interface InterfaceStepArray
{
    void ChangeEvenNumbers();
}

