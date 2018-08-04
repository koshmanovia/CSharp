using System;
    class Example3
    {
        static void Main(string[] args)
        {
        int ivar = 100;
        double dvar = 100.0;

        Console.WriteLine("Значение ivar = " + ivar);
        Console.WriteLine("Значение dvar = " + dvar);
        Console.WriteLine();

        ivar = ivar / 3;
        dvar = dvar / 3;
        Console.WriteLine("Значение ivar = " + ivar);
        Console.WriteLine("Значение dvar = " + dvar);
        Console.ReadKey();

    }
}

