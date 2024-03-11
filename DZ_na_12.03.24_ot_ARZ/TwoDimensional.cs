using System;
sealed class TwoDimensional : MainClass, InterfaceTwoDimensional //ДВУМЕРНЫЙ МАССИВ
{
    private Random random = new Random();
    private int[,] _array;
    public TwoDimensional(bool consoleValues = false)
    {
        CreateAgain(consoleValues);
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
            Console.WriteLine("Введите значения в 1 строку в 1 строке с пробелами между элементами: ");
            string input = Console.ReadLine();
            string[] input_lst = input.Split();
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = int.Parse(input_lst[j]);
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
                _array[i, j] = random.Next(0, 100);
            }
        }
    }

    protected override void RandomArray()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = random.Next(0, 100);
            }
        }
    }



    public override void middleValue()//СРЕДНЕЕ ЗНАЧЕНИЕ ДВУМЕРНОГО МАССИВА:
    {
        Console.WriteLine("\nTask 4");
        int summ = 0;
        foreach (int number in _array)
        {
            summ += number;
        }
        decimal avg = summ / _array.Length;
        Console.WriteLine($"Average = {avg}");
    }

    public override void Print() //ВЫВОД ДВУМЕРНОГО  МАССИВА:
    {
        Console.WriteLine("Вывод массива:");

        for (int x = 0; x < _array.GetLength(0); x++)
        {
            for (int y = 0; y < _array.GetLength(1); y++)
            {
                Console.Write(_array[x, y] + " ");
            }
            Console.WriteLine(" ");
        }

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

