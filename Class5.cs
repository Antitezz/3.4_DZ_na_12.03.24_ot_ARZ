using System;
sealed class StepArray : MainClass, InterfaceStepArray
{
    private Random _random = new Random();
    private int[][] _array;
    public ManyDimension(bool consoleValues = false)
    {
        Recreate(consoleValues);
    }

    public override void Recreate(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите количество массивов в большом массиве: ");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size][];
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
                _array[i][j] = int.Parse(input_lst[j]);
            }
        }
    }
    protected override void RandomArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine("Введите размер внутреннего массива: ");
            int size = int.Parse(Console.ReadLine());
            _array[i] = new int[size];
            for (int j = 0; j < _array[i].Length; j++)
            {
                _array[i][j] = _random.Next(1, 100);
            }
        }
    }

    public override void Print()
    {
        Print(_array);
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

    private static void Print(int[][] _array)//ВЫВОД СТУПЕНЧАТОГО МАССИВА:
    {
        Console.WriteLine("Вывод массива:");

        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                Console.Write(_array[x][y] + " ");
            }
            Console.WriteLine(" ");
        }

    }

    public void FillKeyboard()//МЕТОД ВВОДА С КЛАВИАТУРЫ:
    {
        Console.WriteLine("Ввод с клавиатуры:");

        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                Console.Write($"[{x}][{y}] = ");
                _array[x][y] = int.Parse(Console.ReadLine());
            }
        }

    }

    public override void MiddleValue()// СРЕДНЕЕ ЗНАЧЕНИЕ В МАССИВЕ:
    {
        Console.WriteLine("\nTask 6");
        for (int i = 0; i < _array.Length; i++)
        {
            int summ = 0;
            for (int j = 0; j < _array[i].Length; j++)
            {
                summ += _array[i][j];
            }
            decimal avg = summ / _array[i].Length;
            Console.WriteLine($"Среднее значение в {i} внутреннем массиве = {avg}");
        }
        MiddleValueOfAll();
    }


    private void MiddleValueOfAll()// СРЕДНЕЕ ЗНАЧЕНИЕ ВО ВСЕХ МАССИВАХ:
    {
        Console.WriteLine("\nTask 7");
        int summ = 0;
        int totalLength = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array[i].Length; j++)
            {
                summ += _array[i][j];
                totalLength++;
            }
        }
        decimal avg = summ / totalLength;
        Console.WriteLine($"Среднее значение всех элементов массива = {avg}");
    }

    public void ChangeEvenNumbers()// ИЗМЕНЕНИЕ ВСЕХ ЧЕТНИХ ПО ЗНАЧЕНИЮ ЭЛЕМЕНТА МАССИВА НА ПРОИЗВЕДЕНИЯ ИХ ИНДЕКСОВ:
    {
        Console.WriteLine("\nTask 8");
        int[][] newArray = new int[_array.Length][];
        Array.Copy(_array, newArray, _array.Length);
        for (int i = 0; i < _array.Length; i++)
        {
            for (int y = 0; y < _array[i].Length; y++)
            {
                if (_array[i][y] % 2 == 0)
                {
                    newArray[i][y] = i * y;
                }
            }
        }
        Print(newArray);
    }
}
