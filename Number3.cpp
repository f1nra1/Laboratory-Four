#include <iostream>
#include <vector>

using namespace std;

int main() {
    int j, k, m, total;
    int s0, s1;

    // Ввод параметров
    cout << "Введите j (запаздывание 1): ";
    cin >> j;

    cout << "Введите k (запаздывание 2): ";
    cin >> k;

    cout << "Введите S0 (первый элемент): ";
    cin >> s0;

    cout << "Введите S1 (второй элемент): ";
    cin >> s1;

    cout << "Введите модуль m: ";
    cin >> m;

    cout << "Введите длину последовательности: ";
    cin >> total;

    // Начальные значения
    vector<int> S = {s0, s1};

    // Генерация последовательности
    for (int n = 2; n < total; ++n) {
        int next = (S[n - j] + S[n - k]) % m;
        S.push_back(next);
    }

    // Вывод результата
    cout << "Последовательность: ";
    for (int x : S)
        cout << x << " ";
    cout << endl;

    return 0;
}
