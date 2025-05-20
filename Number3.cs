class Program
{
    static void Main()
    {
        int j, k, m, total;
        int s0, s1;

        // Ввод параметров
        Console.Write("Введите j (запаздывание 1): ");
        j = int.Parse(Console.ReadLine());

        Console.Write("Введите k (запаздывание 2): ");
        k = int.Parse(Console.ReadLine());

        Console.Write("Введите S0 (первый элемент): ");
        s0 = int.Parse(Console.ReadLine());

        Console.Write("Введите S1 (второй элемент): ");
        s1 = int.Parse(Console.ReadLine());

        Console.Write("Введите модуль m: ");
        m = int.Parse(Console.ReadLine());

        Console.Write("Введите длину последовательности: ");
        total = int.Parse(Console.ReadLine());

        // Начальные значения
        List<int> S = new List<int> { s0, s1 };

        // Генерация последовательности
        for (int n = 2; n < total; ++n)
        {
            int next = (S[n - j] + S[n - k]) % m;
            S.Add(next);
        }

        // Вывод результата
        Console.Write("Последовательность: ");
        foreach (int x in S)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}
