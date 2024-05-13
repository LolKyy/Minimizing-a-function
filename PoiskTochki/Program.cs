using System;

class OptimizationMethods
{
    // Функция, которую нужно минимизировать
    public static double Function(double x)
    {
        return x * x - 4; // Пример: x^2 - 4
    }

    // Метод деления отрезка пополам (метод бисекции)
    public static double Bisection(double a, double b, double epsilon)
    {
        while (Math.Abs(b - a) > epsilon)
        {
            double mid = (a + b) / 2;
            double fMid = Function(mid);

            if (fMid == 0)
                return mid;
            else if (fMid * Function(a) < 0)
                b = mid;
            else
                a = mid;
        }
        return (a + b) / 2;
    }

    // Метод золотого сечения
    public static double GoldenSection(double a, double b, double epsilon)
    {
        const double phi = 1.618033988749895; // Золотое сечение

        double x1 = b - (b - a) / phi;
        double x2 = a + (b - a) / phi;

        while (Math.Abs(b - a) > epsilon)
        {
            double f1 = Function(x1);
            double f2 = Function(x2);

            if (f1 < f2)
                b = x2;
            else
                a = x1;

            x1 = b - (b - a) / phi;
            x2 = a + (b - a) / phi;
        }
        return (a + b) / 2;
    }

    // Метод касательных (метод Ньютона)
    public static double Newton(double x0, double epsilon)
    {
        double x = x0;

        while (true)
        {
            double f = Function(x);
            double df = 2 * x; // Производная функции (в данном примере)

            double xNext = x - f / df;

            if (Math.Abs(xNext - x) < epsilon)
                return xNext;

            x = xNext;
        }
    }

    // Метод Фибоначчи
    public static double Fibonacci(double a, double b, double epsilon)
    {
        double fibNMinus2 = 0; // (n-2)-е число Фибоначчи
        double fibNMinus1 = 1; // (n-1)-е число Фибоначчи
        double fibN = fibNMinus1 + fibNMinus2; // n-е число Фибоначчи

        // Находим такое число Фибоначчи, что (b - a) / fibN < epsilon
        while ((b - a) / fibN > epsilon)
        {
            fibNMinus2 = fibNMinus1;
            fibNMinus1 = fibN;
            fibN = fibNMinus1 + fibNMinus2;
        }

        double x1 = a + fibNMinus2 / fibN * (b - a);
        double x2 = a + fibNMinus1 / fibN * (b - a);

        while (Math.Abs(b - a) > epsilon)
        {
            if (Function(x1) < Function(x2))
            {
                b = x2;
                x2 = x1;
                x1 = a + fibNMinus2 / fibN * (b - a);
            }
            else
            {
                a = x1;
                x1 = x2;
                x2 = a + fibNMinus1 / fibN * (b - a);
            }
        }

        return (a + b) / 2;
    }

    static void Main()
    {
        double a;
        while (true)
        {
            Console.Write("Введите начальную точку отрезка: ");
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                break; // Если преобразование прошло успешно, выходим из цикла
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число слишком большое или слишком маленькое.");
            }
        }

        double b;
        while (true)
        {
            Console.Write("Введите конечную точку отрезка: ");
            try
            {
                b = Convert.ToDouble(Console.ReadLine());
                break; // Если преобразование прошло успешно, выходим из цикла
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число слишком большое или слишком маленькое.");
            }
        }

        double epsilon;
        while (true)
        {
            Console.Write("Введите точность: ");
            try
            {
                epsilon = Convert.ToDouble(Console.ReadLine());
                break; // Если преобразование прошло успешно, выходим из цикла
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число слишком большое или слишком маленькое.");
            }
        }


        double resultBisection = Bisection(a, b, epsilon);
        double resultGoldenSection = GoldenSection(a, b, epsilon);
        double resultNewton = Newton(a, epsilon);
        double resultFibonacci = Fibonacci(a, b, epsilon);

        Console.WriteLine($"Минимум (метод бисекции): {resultBisection}");
        Console.WriteLine($"Минимум (метод золотого сечения): {resultGoldenSection}");
        Console.WriteLine($"Минимум (метод Ньютона): {resultNewton}");
        Console.WriteLine($"Минимум (метод Фибоначчи): {resultFibonacci}");
    }
}