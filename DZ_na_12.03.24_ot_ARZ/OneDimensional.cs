using System;
sealed class OneDimensional : ArrayBase
{
    private T[] _array;
    private IElementGenerator<T> _elementGenerator;
    public OneDimension(IElementGenerator<T> ElementGenerator, bool consoleValues = false)
    {
        _elementGenerator = ElementGenerator;
        CreateArray(consoleValues);
    }

    public override void Recreate(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    public override void Print()//МЕТОД ВЫВОДЯЩИЙ ОДНОМЕРНЫЙ МАССИВ:
    {
        Print(_array);
        Console.WriteLine();
    }
    
    private static void Print(T[] array)
    {
        for (int h = 0; h < array.Length; h++)
        {
            Console.Write($"{array[h]} ");
        }
        Console.WriteLine();
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите размер строки: ");
        int size = int.Parse(Console.ReadLine());
        _array = new T[size];
        base.CreateArray(consoleValues);
    }

    protected override void RandomArray()
    {
        for (int i = 0; i < _array.Length;i++)
        {
            _array[i] = _elementGenerator.GenerateRandom();
        }
    }
    
    protected override void InputArray()
    {
        Console.WriteLine($"Введите строку со всеми значениями массива, разделенными пробелами. ( тип должен быть {typeof(T)})");
        string input = Console.ReadLine();
        string[] inputList = input.Split();
        for (int i = 0; i< inputList.Length; i++)
        {
            T inputToType = (T)Convert.ChangeType(inputList[i], typeof(T));
            _array[i] = inputToType;
        }
    }
}
