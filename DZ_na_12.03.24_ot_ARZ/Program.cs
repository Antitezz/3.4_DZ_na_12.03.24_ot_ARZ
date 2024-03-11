using System;
public abstract class ArrayBase : IDimension
{
    public void PublicInputArray()
    {
        InputArray();
    }
    protected abstract void InputArray();
    public void PublicRandomArray()
    {
        RandomArray();
    }
    protected abstract void RandomArray();
    public void PublicCreateArray(bool userValues = false)
    {
        CreateArray(userValues);
    }
    protected abstract void CreateArray(bool userValues = false);
    public abstract void Average();
    public abstract void Print();
    public abstract void Recreate(bool userValues = false);
}

interface IDimension : IPrinter
{
    void PublicInputArray();
    void PublicRandomArray();
    void PublicCreateArray(bool userValues = false);
    void Average();
    void Recreate(bool userValues = false);
}

interface IPrinter
{
    void Print();
}

interface IOneDimension
{
    void DeleteOver();
    void Unique();
}

interface ITwoDimension
{
    int GetDeterminant();
}

interface IManyDimension
{
    void EvenNumChange();
}

sealed class OneDimension : ArrayBase, IOneDimension
{
    private Random _random = new Random();
    private int[] _array;
    public OneDimension(bool userValues = false)
    {
        Recreate(userValues);
    }

    public override void Recreate(bool userValues = false)
    {
        CreateArray(userValues);
    }

    public override void Print()
    {
        Print(_array);
    }

    private static void Print(int[] array)
    {
        for (int h = 0; h < array.Length; h++)
        {
            Console.Write($"{array[h]} ");
        }
        Console.WriteLine();
    }

    protected override void CreateArray(bool userValues = false)
    {
        Console.WriteLine("Enter size of an array");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size];
        if (!userValues)
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
        Console.WriteLine("Enter a string with all values of an array separated by spaces");
        string input = Console.ReadLine();
        string[] inputLst = input.Split();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = int.Parse(inputLst[i]);
        }
    }


    public override void Average()
    {
        int summ = 0;
        foreach (int number in _array)
        {
            summ += number;
        }
        decimal avg = summ / _array.Length;
        Console.WriteLine($"Average = {avg}");
    }

    public void DeleteOver()
    {
        int newArrayLength = _array.Length;
        for (int x = 0; x < _array.Length; x++)
        {
            if (Math.Abs(_array[x]) > 100)
            {
                newArrayLength--;
            }
        }
        int[] array2 = new int[newArrayLength];
        int counter = 0;
        for (int x = 0; x < _array.Length; x++)
        {
            if (!(Math.Abs(_array[x]) > 100))
            {
                array2[counter] = _array[x];
                counter++;
            }
        }
        Print(array2);
    }


    public void Unique()
    {
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
        int counter = 0;
        int[] newArray = new int[newArrayLength];
        for (int a = 0; a < _array.Length; a++)
        {
            if (!Contain(newArray, _array[a]))
            {
                newArray[counter] = _array[a];
                counter++;
            }
        }
        Print(newArray);
    }

    public bool Contain(int[] array, int symb)
    {
        for (int g = 0; g < array.Length; g++)
        {
            if (symb == array[g])
            {
                return true;
            }
        }
        return false;
    }
}

sealed class TwoDimension : ArrayBase, ITwoDimension
{
    private Random random = new Random();
    private int[,] _array;
    public TwoDimension(bool userValues = false)
    {
        Recreate(userValues);
    }

    public override void Recreate(bool userValues = false)
    {
        CreateArray(userValues);
    }

    protected override void CreateArray(bool userValues = false)
    {
        Console.WriteLine("Enter amount of lines of an array");
        int line = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter amount of columns of an array");
        int column = int.Parse(Console.ReadLine());
        _array = new int[line, column];
        if (!userValues)
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
            Console.WriteLine("Enter values of 1 line in 1 string with spaces between elements");
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

    public override void Average()
    {
        int summ = 0;
        foreach (int number in _array)
        {
            summ += number;
        }
        decimal avg = summ / _array.Length;
        Console.WriteLine($"Average = {avg}");
    }

    public override void Print()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("And an array with reversed even lines");
        PrintEvenLines();
    }

    private void PrintEvenLines() //элементы четных строк в обратном порядке
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

    private int Split_array(int[,] array) //здесь и дальше алгоритм поиска определителя матрицы
    {
        int total = 0;
        int counter = 0;
        int sizeOfArray = array.GetLength(0);
        int newSize = sizeOfArray - 1;
        if (sizeOfArray == 2)
        {
            return FindDefinitor(array);
        }
        else
        {
            for (int n = 0; n < sizeOfArray; n++)
            {
                int[,] newArray = new int[newSize, newSize];
                for (int line = 1; line < sizeOfArray; line++)
                {
                    for (int col = 0; col < sizeOfArray; col++)
                    {
                        if (col != n)
                        {
                            if (n == sizeOfArray - 1)
                            {
                                newArray[line - 1, col] = array[line, col];
                            }
                            else
                            {
                                if (col != 0)
                                {
                                    if (col < newSize & newArray[line - 1, col - 1] != 0)
                                    {
                                        newArray[line - 1, col] = array[line, col];
                                    }
                                    else
                                    {
                                        newArray[line - 1, col - 1] = array[line, col];
                                    }
                                }
                                else
                                {
                                    newArray[line - 1, col] = array[line, col];
                                }
                            }
                        }
                    }
                }
                int k = 0;
                if (counter % 2 == 0)
                {
                    k = 1;
                }
                else
                {
                    k = -1;
                }
                counter += 1;
                if (newSize == 2)
                {
                    int definer = TwoMansion(array, newArray, n, k);
                    total += definer;
                }
                else
                {
                    if (n % 2 == 0)
                    {
                        total += Split_array(newArray) * array[0, n] * k;
                    }
                    else
                    {
                        total += Split_array(newArray) * array[0, n] * k;
                    }
                }
            }
        }
        return total;
    }
    private static int FindDefinitor(int[,] array) //Находит определитель двоичной матрицы
    {
        int definitor = (array[0, 0] * array[1, 1]) - (array[1, 0] * array[0, 1]);
        return definitor;
    }
    private static int TwoMansion(int[,] oldArray, int[,] newArray, int n, int k) /*Перемножает элемент (oldArray[0, n]) на его алгебраическое дополнение (definitor)                                                                                c учетом коэффициента порядка (k)*/
    {
        int definitor = FindDefinitor(newArray);
        definitor = oldArray[0, n] * k * definitor;
        return definitor;
    }

    public int GetDeterminant()
    {
        return Split_array(_array);
    }

}

sealed class ManyDimension : ArrayBase, IManyDimension
{
    private Random _random = new Random();
    private int[][] _array;
    public ManyDimension(bool userValues = false)
    {
        Recreate(userValues);
    }

    public override void Recreate(bool userValues = false)
    {
        CreateArray(userValues);
    }

    protected override void CreateArray(bool userValues = false)
    {
        Console.WriteLine("Enter amount of arrays in a big array");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size][];
        if (!userValues)
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
            Console.WriteLine("Enter size of an inner array");
            int size = int.Parse(Console.ReadLine());
            _array[i] = new int[size];
            Console.WriteLine("Enter values of 1 inner array in 1 string with spaces between elements");
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
            Console.WriteLine("Enter size of an inner array");
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

    private static void Print(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write($"{array[i][j]} ");
            }
            Console.WriteLine();
        }
    }

    public override void Average()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            int summ = 0;
            for (int j = 0; j < _array[i].Length; j++)
            {
                summ += _array[i][j];
            }
            decimal avg = summ / _array[i].Length;
            Console.WriteLine($"Average of values in {i} inner array = {avg}");
        }
        AverageOfAll();
    }

    private void AverageOfAll()
    {
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
        Console.WriteLine($"Average of all elements in array = {avg}");
    }

    public void EvenNumChange()
    {
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