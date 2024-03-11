using System;
public abstract class Mainclass : InterfaceDimension
{
    public void PublicInputArray()
    {
        InputArray();
    }
    protected abstract void InputArray();
    public void PublicRandomArray()
    {
        RandomArray();
    }
    protected abstract void RandomArray();
    public void PublicCreateArray(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }
    protected abstract void CreateArray(bool consoleValues = false);
    public abstract void MiddleValue();
    public abstract void Print();
    public abstract void CreateAgain(bool consoleValues = false);
}

