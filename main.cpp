#include <iostream>
#include <vector>
#include "func.h"

using namespace std;

int main() {
    double eps = 0.0001; // Задаем точность вычислений
    double from = -10.0, to = 10.0, step = 0.1; // Диапазон поиска корней и шаг

    vector<pair<double, double>> intervals;
    double x1 = from, x2 = x1 + step;

    while (x2 <= to) // Поиск всех интервалов, в которых функция меняет знак (возможные корни)
    {
        if (f(x1) * f(x2) < 0)
            intervals.emplace_back(x1, x2); // Добавляем интервал в список
        x1 = x2;
        x2 += step;
    }

    if (intervals.empty())
    {
        cout << "Корни не найдены.\n";
        return 1;
    }

    cout << "\nНайдено интервалов с корнями: " << intervals.size() << "\n";
    int i = 1;
    for (const auto& p : intervals)
    {
        cout << "  Интервал #" << i++ << ": ["
             << p.first << ", "
             << p.second << "]\n";
    }

    int idx = 1;
    for (const auto& [a, b] : intervals)
    {
        cout << "\n====================================\n";
        cout << "  Корень #" << idx++ << " в интервале ["
             << a << ", " << b << "]\n";
        cout << "====================================\n";

        cout << "Выберите метод: "
             <<"\n1 - Метод половинного деления"
             <<"\n2 - Метод Ньютона"
             <<"\n3 - Метод простых итераций\n";
        int choice;
        cin >> choice;
        if (choice < 1 || choice > 3) {
            cout << "Неверный выбор метода.\n";
            return 1;
        }

        int bisect_iter = 0, newton_iter = 0, iter_iter = 0;
        double x0 = (a + b) / 2; // Начальное приближение для Ньютона и итераций

        Method method = static_cast<Method>(choice); // Преобразуем ввод пользователя в элемент enum
        switch (method) {
            case Method::Bisection:
                bisection(a, b, eps, bisect_iter);
                break;
            case Method::Newton:
                newton(x0, eps, newton_iter);
                break;
            case Method::Iteration:
                iteration(x0, eps, iter_iter);
                break;
        }
    }
    return 0;
}
