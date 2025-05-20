#include "func.h"
#include <iostream>
#include <iomanip>
#include <cmath>

using namespace std;

double f(double x) { // Целевая функция
    return cos(x + 0.3) - x * x;
}

double df(double x) {
    return -sin(x + 0.3) - 2 * x; // Производная функции для метода Ньютона
}

double phi(double x) { // Функция итерации (φ(x)) для метода простых итераций
    return sqrt(cos(x + 0.3));
}

void bisection(double a, double b, double eps, int& iterations) {
    cout << "\nМетод половинного деления:\n";
    cout << " N     an         bn        bn - an\n";
    cout << "--------------------------------------\n";
    iterations = 0;
    double c;

    while ((b - a) > eps) { // Пока длина интервала больше заданной точности
        c = (a + b) / 2; // Середина интервала
        cout << setw(2) << iterations << "  "
             << setw(9) << fixed << setprecision(6) << a << "  "
             << setw(9) << b << "  "
             << setw(9) << b - a << '\n';

        if (f(a) * f(c) < 0) // Определение нового интервала, в котором сохраняется смена знака
            b = c;
        else
            a = c;

        iterations++;
    }

    double x = (a + b) / 2; // Итоговое приближение
    cout << "\nРезультат: x* = " << x << ", f(x*) = " << f(x)
         << ", итераций: " << iterations << "\n";
}

void newton(double x0, double eps, int& iterations)
{
    cout << "\nМетод Ньютона:\n";
    cout << " N      xn        xn+1      |xn+1 - xn|\n";
    cout << "----------------------------------------\n";
    iterations = 0;
    double x1;

    do
    {
        double fx = f(x0);
        double dfx = df(x0);
        if (abs(dfx) < 0.0001)
        {
            cout << "Производная близка к нулю. Метод не применим.\n";
            return;
        }

        x1 = x0 - fx / dfx; // Основная формула метода Ньютона

        cout << setw(2) << iterations << "  " // Вывод текущего шага
             << setw(9) << fixed << setprecision(6) << x0 << "  "
             << setw(9) << x1 << "  "
             << setw(9) << abs(x1 - x0) << '\n';

        x0 = x1; // Подготовка к следующей итерации
        iterations++;
    } while (abs(f(x1)) > eps);

    cout << "\nРезультат: x* = " << x1 << ", f(x*) = " << f(x1)
         << ", итераций: " << iterations << "\n";
}

void iteration(double x0, double eps, int& iterations) {
    cout << "\nМетод простых итераций:\n";
    cout << " N      xn        xn+1      |xn+1 - xn|\n";
    cout << "----------------------------------------\n";
    iterations = 0;
    double x1;

    do {
        double cos_val = cos(x0 + 0.3); // Вычисляем значение под корнем
        if (cos_val < 0) { // Проверка что значние не отрицательное
            cout << "cos(x + 0.3) < 0 -> корень невозможен\n";
            return;
        }

        x1 = sqrt(cos_val); // Функция фи(x)

        cout << setw(2) << iterations << "  "
             << setw(9) << fixed << setprecision(6) << x0 << "  "
             << setw(9) << x1 << "  "
             << setw(9) << abs(x1 - x0) << '\n';

        if (abs(x1 - x0) < eps)
            break;

        x0 = x1;
        iterations++;
    } while (iterations < 100); // Ограничение по числу итераций, чтобы не зациклиться

    cout << "\nРезультат: x* = " << x1 << ", f(x*) = " << f(x1)
         << ", итераций: " << iterations << "\n";
}
