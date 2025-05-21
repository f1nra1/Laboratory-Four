class Program
{
    // Возвращает индекс кандидата в предпочтениях избирателя
    static int IndexOf(List<string> ranking, string name)
    {
        for (int i = 0; i < ranking.Count; i++)
        {
            if (ranking[i] == name) return i;
        }
        return -1; // не найден
    }

    static void Main()
    {
        Console.Write("Введите количество кандидатов: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество избирателей: ");
        int k = int.Parse(Console.ReadLine());

        List<string> candidates = new List<string>();
        Console.WriteLine("Введите имена кандидатов:");
        for (int i = 0; i < n; ++i)
        {
            candidates.Add(Console.ReadLine());
        }

        List<List<string>> votes = new List<List<string>>();
        Console.WriteLine("\nВведите предпочтения избирателей (от первого до последнего кандидата):");
        for (int i = 0; i < k; ++i)
        {
            Console.Write($"Избиратель #{i + 1}: ");
            List<string> vote = new List<string>();
            for (int j = 0; j < n; ++j)
            {
                string name = Console.ReadLine();
                vote.Add(name);
            }
            votes.Add(vote);
        }

        // ===== Метод Борда =====
        Dictionary<string, int> bordaScores = new Dictionary<string, int>();
        foreach (var vote in votes)
        {
            for (int i = 0; i < n; ++i)
            {
                if (!bordaScores.ContainsKey(vote[i]))
                    bordaScores[vote[i]] = 0;
                bordaScores[vote[i]] += n - 1 - i;
            }
        }

        int maxScore = -1;
        List<string> bordaWinners = new List<string>();
        foreach (var entry in bordaScores)
        {
            if (entry.Value > maxScore)
            {
                maxScore = entry.Value;
                bordaWinners = new List<string> { entry.Key };
            }
            else if (entry.Value == maxScore)
            {
                bordaWinners.Add(entry.Key);
            }
        }

        // ===== Метод Кондорсе =====
        Dictionary<string, int> condorcetWins = new Dictionary<string, int>();
        foreach (var a in candidates)
        {
            foreach (var b in candidates)
            {
                if (a == b) continue;
                int countA = 0, countB = 0;
                foreach (var vote in votes)
                {
                    if (IndexOf(vote, a) < IndexOf(vote, b))
                        countA++;
                    else
                        countB++;
                }
                if (countA > countB)
                {
                    if (!condorcetWins.ContainsKey(a))
                        condorcetWins[a] = 0;
                    condorcetWins[a]++;
                }
            }
        }

        List<string> condorcetWinners = new List<string>();
        foreach (var entry in condorcetWins)
        {
            if (entry.Value == n - 1)
            {
                condorcetWinners.Add(entry.Key);
            }
        }

        // ===== Результаты =====
        Console.WriteLine("\n--- Результаты выборов ---");

        if (bordaWinners.Count == 1)
        {
            Console.WriteLine($"Победитель по методу Борда: {bordaWinners[0]} (баллы: {bordaScores[bordaWinners[0]]})");
        }
        else
        {
            Console.Write("Метод Борда: Ничья между кандидатами: ");
            foreach (var name in bordaWinners)
            {
                Console.Write($"{name} (баллы: {bordaScores[name]}) ");
            }
            Console.WriteLine();
        }

        if (condorcetWinners.Count == 0)
        {
            Console.WriteLine("Метод Кондорсе: Победителя не существует (циклические предпочтения)");
        }
        else if (condorcetWinners.Count == 1)
        {
            Console.WriteLine($"Победитель по методу Кондорсе: {condorcetWinners[0]}");
        }
        else
        {
            Console.Write("Метод Кондорсе: Ничья между кандидатами: ");
            foreach (var name in condorcetWinners)
            {
                Console.Write($"{name} ");
            }
            Console.WriteLine();
        }

        // Комментарий
        if (bordaWinners.Count == 1 && condorcetWinners.Count == 1 &&
            bordaWinners[0] != condorcetWinners[0])
        {
            Console.WriteLine("\nМетоды Борда и Кондорсе дали разные результаты. " +
                "Это возможно при сложных или циклических предпочтениях избирателей.");
        }
    }
}
