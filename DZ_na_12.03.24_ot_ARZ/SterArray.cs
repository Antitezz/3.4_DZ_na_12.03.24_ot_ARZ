using System;
sealed class StepArray :ArrayBase
{
    private T[][] _array;
    private IElementGenerator<T> _elementGenerator;
    public ManyDimension(IElementGenerator<T> elementGenerator, bool userValues = false)
    {
        _elementGenerator = elementGenerator;
        CreateArray(userValues);
    }

    public override void CreateAgain(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите количество массивов в большом массиве: ");
        int size = int.Parse(Console.ReadLine());
        _array = new T[size][];
        base.CreateArray(consoleValues);
    }

    protected override void InputArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine("Введите размер внутреннего массива: ");
            int size = int.Parse(Console.ReadLine());
            _array[i] = new int[size];
            Console.WriteLine("Введите значения 1 внутреннего массива в 1 строку с пробелами между элементами: ");
            string input = Console.ReadLine();
            string[] input_lst = input.Split();
            for (int j = 0; j < _array[i].Length; j++)
            {
                 T inputToType = (T)Convert.ChangeType(inputList[j], typeof(T));
                _array[i][j] = inputToType;
            }
        }
    }

    public void FillRandom()// МЕТОД ЗАПОЛНЕНИЯ МАССИВА СЛУЧАЙНЫМИ ЧИСЛАМИ:
    {
        Console.WriteLine("\nTask 6");
        Random random = new Random();
        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                _array[x][y] = random.Next(0, 10);
            }
        }
    }

    public override void Print()
    {
        Print(_array);
        Console.WriteLine();
    }

    private static void Print(T[][] array)//ВЫВОД СТУПЕНЧАТОГО МАССИВА:
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j=0; j < array[i].Length; j++)
            {
                Console.Write($"{array[i][j]} ");
            }
            Console.WriteLine();
        }
    }
}
