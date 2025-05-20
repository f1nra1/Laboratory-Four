namespace RootFinder{
    public static class Functions{
        // Целевая функция
        public static double F(double x){
            return Math.Cos(x + 0.3) - x * x;
        }
        // Производная функции для метода Ньютона
        public static double DF(double x){
            return -Math.Sin(x + 0.3) - 2 * x;
        }
        // Функция итерации (φ(x)) для метода простых итераций
        public static double Phi(double x)
        {
            double cosVal = Math.Cos(x + 0.3);
            if (cosVal < 0)
            {
                Console.WriteLine("Ошибка: cos(x + 0.3) < 0 -> sqrt невозможно");
                return double.NaN;
            }
            return Math.Sqrt(cosVal);
        }

        // Метод половинного деления
        public static void Bisection(double a, double b, double eps, ref int iterations)
        {
            Console.WriteLine("\nМетод половинного деления:");
            Console.WriteLine(" N     an         bn        bn - an");
            Console.WriteLine("--------------------------------------");
            iterations = 0;
            double c;

            while ((b - a) > eps) // Пока длина интервала больше заданной точности
            {
                c = (a + b) / 2; // Середина интервала
                Console.WriteLine($"{iterations,2}  {a,9:F6}  {b,9:F6}  {b - a,9:F6}");

                if (F(a) * F(c) < 0) // Определение нового интервала, в котором сохраняется смена знака
                    b = c;
                else
                    a = c;

                iterations++;
            }

            double x = (a + b) / 2; // Итоговое приближение
            Console.WriteLine($"\nРезультат: x* = {x:F6}, f(x*) = {F(x):F6}, итераций: {iterations}");
        }

        // Метод Ньютона
        public static void Newton(double x0, double eps, ref int iterations)
        {
            Console.WriteLine("\nМетод Ньютона:");
            Console.WriteLine(" N      xn        xn+1      |xn+1 - xn|");
            Console.WriteLine("----------------------------------------");
            iterations = 0;
            double x1;

            do
            {
                double fx = F(x0);
                double dfx = DF(x0);
                if (Math.Abs(dfx) < 0.0001)
                {
                    Console.WriteLine("Производная близка к нулю. Метод не применим.");
                    return;
                }
                x1 = x0 - fx / dfx; // Основная формула метода Ньютона
                Console.WriteLine($"{iterations,2}  {x0,9:F6}  {x1,9:F6}  {Math.Abs(x1 - x0),9:F6}");
                x0 = x1; // Подготовка к следующей итерации
                iterations++;
            } while (Math.Abs(F(x1)) > eps);

            Console.WriteLine($"\nРезультат: x* = {x1:F6}, f(x*) = {F(x1):F6}, итераций: {iterations}");
        }
        // Метод простых итераций
        public static void Iteration(double x0, double eps, ref int iterations)
        {
            Console.WriteLine("\nМетод простых итераций:");
            Console.WriteLine(" N      xn        xn+1      |xn+1 - xn|");
            Console.WriteLine("----------------------------------------");
            iterations = 0;
            double x1;

            do
            {
                x1 = Phi(x0);
                if (double.IsNaN(x1)) return; // Ошибка при вычислении Phi
                Console.WriteLine($"{iterations,2}  {x0,9:F6}  {x1,9:F6}  {Math.Abs(x1 - x0),9:F6}");
                if (Math.Abs(x1 - x0) < eps)
                    break;
                x0 = x1;
                iterations++;
            } while (iterations < 100); // Ограничение по числу итераций, чтобы не зациклиться
            Console.WriteLine($"\nРезультат: x* = {x1:F6}, f(x*) = {F(x1):F6}, итераций: {iterations}");
        }
    }
}