using NumberGenerator;
using System.Text;
using System.Collections.Generic;
using System.Threading;

public enum GeneratorType
{
    Prime,
    Fibonacci
}

class Program
{
    static Dictionary<GeneratorType, NumberGenerator.NumberGenerator> generators =
        new Dictionary<GeneratorType, NumberGenerator.NumberGenerator>();

    static Dictionary<GeneratorType, Thread> threads = new Dictionary<GeneratorType, Thread>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("Виберіть опцію:");
            Console.WriteLine("1. Генерувати прості числа");
            Console.WriteLine("2. Генерувати числа Фібоначчі");
            Console.WriteLine("3. Зупинити генерацію простих чисел");
            Console.WriteLine("4. Зупинити генерацію чисел Фібоначчі");
            Console.WriteLine("5. Вихід");

            Console.Write(">>> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    GenerateNumbers(GeneratorType.Prime);
                    break;
                case "2":
                    GenerateNumbers(GeneratorType.Fibonacci);
                    break;
                case "3":
                    StopGeneration(GeneratorType.Prime);
                    break;
                case "4":
                    StopGeneration(GeneratorType.Fibonacci);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Невідомий вибір");
                    break;
            }
        }
    }

    static void GenerateNumbers(GeneratorType type)
    {
        Console.Write($"\nВведіть верхню межу для {type}:\n>>> ");
        if (!int.TryParse(Console.ReadLine(), out int upperBound))
        {
            Console.WriteLine("Будь ласка введіть дійсне число");
            return;
        }

        switch (type)
        {
            case GeneratorType.Prime:
                generators[type] = new PrimeGenerator(0, upperBound);
                break;
            case GeneratorType.Fibonacci:
                generators[type] = new FibonacciGenerator(0, upperBound);
                break;
        }

        threads[type] = new Thread(generators[type].Generate);

        Console.WriteLine($"Починається генерація {type} чисел...\n");
        threads[type].Start();
    }

    static void StopGeneration(GeneratorType type)
    {
        if (threads.ContainsKey(type) && threads[type] != null)
        {
            generators[type].Stop();
            threads[type].Join();

            Console.WriteLine();

            generators[type].PrintNumbers();
            Console.WriteLine($"\nГенерація {type} чисел була зупинена\n");

            threads[type] = null;
        }
        else
        {
            Console.WriteLine($"\nГенерація {type} чисел не виконується\n");
        }
    }
}
