class Program
{
    // Инициализация генератора случайных чисел
    static Random rand = new Random();

    // Задание 1: Массив из n чисел [150, 300]
    static void Task1(List<int> arr, int n)
    {
        arr.Clear();
        for (int i = 0; i < n; i++)
        {
            arr.Add(rand.Next(150, 301)); // Генерация случайного числа от 150 до 300
        }

        Console.WriteLine("Задание 1: Исходный массив:");
        foreach (var x in arr)
            Console.Write(x + " ");
        Console.WriteLine("\n");
    }

    // Задание 2: Самая длинная убывающая подпоследовательность
    static void Task2(List<int> arr)
    {
        int maxLen = 1, curLen = 1, endIdx = 0;

        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                curLen++;
                if (curLen > maxLen)
                {
                    maxLen = curLen;
                    endIdx = i;
                }
            }
            else
            {
                curLen = 1;
            }
        }

        Console.WriteLine("Задание 2: Самая длинная убывающая последовательность:");
        if (maxLen > 1)
        {
            for (int i = endIdx - maxLen + 1; i <= endIdx; i++)
                Console.Write(arr[i] + " ");
        }
        else
        {
            Console.WriteLine("Нет убывающей подпоследовательности.");
        }
        Console.WriteLine("\n");
    }

    // Задание 3: Числа, меньшие среднего арифметического
    static void Task3(List<int> arr)
    {
        double avg = arr.Average();
        Console.WriteLine("Задание 3: Среднее значение = " + avg);
        Console.WriteLine("Элементы меньше среднего:");
        foreach (var x in arr)
        {
            if (x < avg) Console.Write(x + " ");
        }
        Console.Write("\n");
    }

    // Задание 4: Модификация массива символов
    static void Task4()
    {
        int n;
        Console.WriteLine("\nЗадание 4. Модификация массива символов");
        Console.Write("Введите размер массива (n >= 5): ");
        n = int.Parse(Console.ReadLine());

        if (n < 5)
        {
            Console.WriteLine("Размер должен быть не менее 5.");
            return;
        }

        List<char> chars = new List<char>();
        for (int i = 0; i < n; i++)
        {
            chars.Add((char)rand.Next(33, 127)); // Диапазон видимых ASCII символов
        }

        Console.WriteLine("Исходный массив: [" + string.Join(", ", chars) + "]");

        // Сдвиг влево на 2 позиции
        char[] shiftedArray = new char[n];
        for (int i = 0; i < n; i++)
        {
            shiftedArray[i] = chars[(i + 2) % n];
        }

        Console.WriteLine("Модифицированный массив: [" + string.Join(", ", shiftedArray) + "]\n");
    }

    // Задание 5: Сортировка и анализ цифр
    static void Task5()
    {
        int n;
        Console.Write("Задание 5: Введите размер массива (n >= 10): ");
        n = int.Parse(Console.ReadLine());

        while (n < 10)
        {
            Console.Write("Ошибка: n >= 10. Повторите: ");
            n = int.Parse(Console.ReadLine());
        }

        List<int> arr = new List<int>();
        for (int i = 0; i < n; i++)
        {
            arr.Add(rand.Next(100, 901)); // Генерация чисел от 100 до 900
        }

        Console.WriteLine("Исходный массив:");
        foreach (var x in arr)
            Console.Write(x + " ");
        Console.WriteLine();

        arr.Sort((a, b) => b.CompareTo(a)); // Сортировка по убыванию

        Console.WriteLine("Отсортированный по убыванию:");
        foreach (var x in arr)
            Console.Write(x + " ");
        Console.WriteLine();

        // Подсчет цифр
        Dictionary<char, int> digitCount = new Dictionary<char, int>();
        foreach (var x in arr)
        {
            foreach (var c in x.ToString())
            {
                if (digitCount.ContainsKey(c))
                    digitCount[c]++;
                else
                    digitCount[c] = 1;
            }
        }

        Console.WriteLine("Частота каждой цифры в массиве:");
        foreach (var kv in digitCount)
        {
            Console.WriteLine(kv.Key + " — " + kv.Value);
        }
    }

    static void Main()
    {
        int n;
        Console.Write("Введите размер массива n (n >= 10): ");
        n = int.Parse(Console.ReadLine());

        while (n < 10)
        {
            Console.Write("Ошибка: n >= 10. Повторите: ");
            n = int.Parse(Console.ReadLine());
        }

        List<int> arr = new List<int>();
        Task1(arr, n);
        Task2(arr);
        Task3(arr);
        Task4();
        Task5();
    }
}
