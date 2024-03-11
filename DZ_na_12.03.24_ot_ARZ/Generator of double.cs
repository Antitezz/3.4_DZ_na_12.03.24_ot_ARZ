using System;

class DoubleGenerator : IElementGenerator<double>
{
    private static Random _random = new Random();
    public double GenerateRandom()
    {
        int coeff = _random.Next(1, 10);
        double number = _random.NextDouble();
        number = Math.Round(number, 2, MidpointRounding.ToEven);
        return number * coeff;
    }
}
