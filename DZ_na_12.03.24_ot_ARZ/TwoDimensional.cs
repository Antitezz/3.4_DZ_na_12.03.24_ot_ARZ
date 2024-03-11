using System;
sealed class TwoDimensional :ArrayBase //ДВУМЕРНЫЙ МАССИВ
{
private T[,] _array;
    private IElementGenerator<T> _elementGenerator;
    public TwoDimension(IElementGenerator<T> elementGenerator, bool consoleValues = false)
    {
        _elementGenerator = elementGenerator;
        CreateArray(consoleValues);
    }

    public override void CreateAgain(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите количество строк массива: ");
        int line = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов массива: ");
        int column = int.Parse(Console.ReadLine());
        _array = new int[line, column];
        if (!consoleValues)
        {
            RandomArray();
        }
        else
        {
            InputArray();
        }
    }

    protected override void InputArray()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            Console.WriteLine($"Введите значения 1 строки в 1 строке с пробелами между элементами.(тип должен быть: {typeof(T)})");
            string input = Console.ReadLine();
            string[] inputList = input.Split();
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                T inputToType = (T)Convert.ChangeType(inputList[j], typeof(T));
                _array[i, j] = inputToType;
            }
        }
        Console.WriteLine();
    }

    protected override void RandomArray()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = _elementGenerator.GenerateRandom();
            }
        }
    }
    
    public override void Print()
    {
        for (int i = 0; i<_array.GetLength(0); i++)
        {
            for (int j = 0; j<_array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("И массив с перевернутыми четными строками:");
        PrintSnake();
        Console.WriteLine();
    }

    public void PrintSnake()
    {
        Console.WriteLine("\nTask 5");
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Введите массив с перевернутыми четными строками:");
        PrintReverseLines();
    }

    private void PrintReverseLines() //ЭЛЕМЕНТЫ ЧЕТНЫХ СТРОК НАОБОРОТ
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            string line = "";
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                if (j != _array.GetLength(1) - 1)
                {
                    line += _array[i, j].ToString() + " ";
                }
                else
                {
                    line += _array[i, j].ToString();
                }
            }
            if (i % 2 == 0)
            {
                line = Reverse(line);
            }
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    private string Reverse(string s)
    {
        string reversed = "";
        string[] s_split = s.Split(' ');
        for (int k = s_split.Length - 1; k >= 0; k--)
        {
            reversed += s_split[k] + " ";
        }
        return reversed;
    }
}

