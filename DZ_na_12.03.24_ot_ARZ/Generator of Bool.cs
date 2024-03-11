class BoolGenerator: IElementGenerator<bool>
{
    private static Random _random = new Random();
    public bool GenerateRandom()
    {
        bool flag = false;
        int determinant = _random.Next(0, 2);
        if (determinant == 1)
        {
            flag = true;
        }
        return flag;
    }
}
