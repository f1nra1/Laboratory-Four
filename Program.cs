namespace RootFinder{
    class Program{
        static void Main(){
            double eps = 0.0001;
            double from = -10.0, to = 10.0, step = 0.1;
            List<(double, double)> intervals = new();
            double x1 = from, x2 = x1 + step;
            while (x2 <= to){
                if (Functions.F(x1) * Functions.F(x2) < 0)
                    intervals.Add((x1, x2));
                x1 = x2;
                x2 += step;
            }

            if (intervals.Count == 0){
                Console.WriteLine("Корни не найдены.");
                return;
            }

            Console.WriteLine($"\nНайдено интервалов с корнями: {intervals.Count}");
            int i = 1;
            foreach (var (a, b) in intervals){
                Console.WriteLine($"  Интервал #{i++}: [{a}, {b}]");
            }

            int idx = 1;
            foreach (var (a, b) in intervals){
                Console.WriteLine("\n====================================");
                Console.WriteLine($"  Корень #{idx++} в интервале [{a}, {b}]");
                Console.WriteLine("====================================");

                Console.WriteLine("Выберите метод:\n1 - Метод половинного деления\n2 - Метод Ньютона\n3 - Метод простых итераций");
                int choice = int.Parse(Console.ReadLine() ?? "1");

                int iterCount = 0;
                double x0 = (a + b) / 2;

                Method method = (Method)choice;
                switch (method)
                {
                    case Method.Bisection:
                        Functions.Bisection(a, b, eps, ref iterCount);
                        break;
                    case Method.Newton:
                        Functions.Newton(x0, eps, ref iterCount);
                        break;
                    case Method.Iteration:
                        Functions.Iteration(x0, eps, ref iterCount);
                        break;
                }
            }
        }
    }
}
