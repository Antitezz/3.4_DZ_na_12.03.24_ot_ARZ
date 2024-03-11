using System;
sealed class OneDimensional : MainClass, InterfaceOneDimensional
{
    private Random _random = new Random();
    private int[] _array;
    public OneDimensional(bool consoleValues = false)
    {
        Recreate(consoleValues);
    }

    public override void Recreate(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    public override void Print()
    {
        Print(_array);
    }

    private static void Print(int[] array)//МЕТОД ВЫВОДЯЩИЙ ОДНОМЕРНЫЙ МАССИВ:
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите размер строки: ");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size];
        if (!consoleValues)
        {
            RandomArray();
        }
        else
        {
            InputArray();
        }
    }

    protected override void RandomArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _random.Next(0, 100);
        }
    }

    protected override void InputArray()
    {
        Console.WriteLine("Введите строку со всеми значениями массива, разделенными пробелами: ");
        string input = Console.ReadLine();
        string[] inputLst = input.Split();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = int.Parse(inputLst[i]);
        }
    }


    public override void MiddleValue()//МЕТОД ВЫВОДЯЩИЙ СРЕДНЕЕ ЗНАЧЕНИЕ МАССИВА:
    {
        Console.WriteLine("\nTask 1");
        int counter = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            counter += _array[i];
        }
        Console.WriteLine(counter / _array.Length);
    }

    public void GetRidofValue()//МЕТОД УДАЛЕНИЯ ЭЛЕМЕНТОВ БОЛЬШЕ 100 ПО МОДУЛЮ:
    {
        Console.WriteLine("\nTask 2");
        int counter = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (Math.Abs(_array[i]) < 100)
            {
                counter += 1;
            }
        }
        int[] newArr = new int[counter];
        int j = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (Math.Abs(_array[i]) < 100)
            {
                newArr[j] = _array[i];
                j++;
            }
        }
        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }
    }

    public void NonRepeat()//МЕТОД БЕЗ ПОВТОРА:
    {
        Console.WriteLine("\nTask 3");
        int newArrayLength = _array.Length;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i; j < _array.Length; j++)
            {
                if (_array[i] == _array[j] && i != j)
                {
                    newArrayLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newArrayLength];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = int.MinValue;
        }
        int counter = 0;

        for (int i = 0; i < _array.Length; i++)
        {
            if (!Exists(_array[i], newArray))
            {
                newArray[counter] = _array[i];
                counter++;
            }
        }
        Print(newArray);
    }
    private static bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
}

