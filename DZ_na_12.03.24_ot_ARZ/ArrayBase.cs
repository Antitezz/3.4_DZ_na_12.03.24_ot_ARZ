﻿using System;
public abstract class ArrayBase : InterfaceDimensional
{
    protected static Random _random = new Random();
    protected virtual void CreateArray(bool consoleValues = false)
    {
        if (consoleValues)
        {
            InputArray();
        }
        else
        {
            RandomArray();
        }
    protected abstract void InputArray();
    protected abstract void RandomArray();
    public abstract void Print();
    public abstract void CreateAgain(bool consoleValues = false);
}

