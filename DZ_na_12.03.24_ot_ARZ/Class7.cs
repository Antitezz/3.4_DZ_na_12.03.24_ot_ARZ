using System.ComponentModel.DataAnnotations.Schema;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Хотите ли вы иметь в массиве случайно сгенерированные значения?");
        string getCreationType = Console.ReadLine();
        bool consoleValues = false;
        if (getCreationType == "нет")
        {
            consoleValues = true;
        }
        InterfaceDimensional[] MainClass = new InterfaceDimensional[3];
        MainClass[0] = new OneDimensional(consoleValues);
        MainClass[1] = new TwoDimensional(consoleValues);
        MainClass[2] = new StepArray(consoleValues);
        Console.WriteLine();
        for (int i = 0; i < MainClass.Length; i++)
        {
            MainClass[i].Print();
            MainClass[i].MiddleValue();
            Console.WriteLine();
        }
        WeekDays weekDays = new WeekDays();
        IPrinter[] printList = new IPrinter[MainClass.Length + 1];
        for (int i = 0; i < printList.Length - 1; i++)
        {
            printList[i] = MainClass[i];
        }
        printList[printList.Length - 1] = weekDays;
        foreach (IPrinter printer in printList)
        {
            printer.Print();
            Console.WriteLine();
        }
    }
}


