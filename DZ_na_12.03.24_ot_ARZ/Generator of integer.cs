using System;

class IntGenerator : IElementGenerator<int>
{
    private static Random _random = new Random();
    public int GenerateRandom()
    {
        return _random.Next(0, 100);
    }
}


