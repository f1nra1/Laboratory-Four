#include <iostream>
#include <vector>
#include <random>
#include <algorithm>
#include <map>
#include <iomanip>
#include <string>

using namespace std;

// Инициализация генератора ranlux24_base
random_device rd;
ranlux24_base gen(rd());

// Задание 1: Массив из n чисел [150, 300]
void task1(vector<int>& arr, int n) {
    uniform_int_distribution<> dist(150, 300);
    arr.resize(n);
    for (int& x : arr) x = dist(gen);

    cout << "Задание 1: Исходный массив:\n";
    for (int x : arr) cout << x << " ";
    cout << "\n\n";
}

// Задание 2: Самая длинная убывающая подпоследовательность
void task2(const vector<int>& arr) {
    int maxLen = 1, curLen = 1, endIdx = 0;

    for (int i = 1; i < arr.size(); ++i) {
        if (arr[i] < arr[i - 1]) {
            curLen++;
            if (curLen > maxLen) {
                maxLen = curLen;
                endIdx = i;
            }
        } else {
            curLen = 1;
        }
    }

    cout << "Задание 2: Самая длинная убывающая последовательность:\n";
    if (maxLen > 1) {
        for (int i = endIdx - maxLen + 1; i <= endIdx; ++i)
            cout << arr[i] << " ";
    } else {
        cout << "Нет убывающей подпоследовательности.";
    }
    cout << "\n\n";
}

// Задание 3: Числа, меньшие среднего арифметического
void task3(const vector<int>& arr) {
    double avg = accumulate(arr.begin(), arr.end(), 0.0) / arr.size();
    cout << "Задание 3: Среднее значение = " << avg << "\n";
    cout << "Элементы меньше среднего:\n";
    for (int x : arr) {
        if (x < avg) cout << x << " ";
    }
    cout << "\n";
}

// Задание 4: Модификация массива символов
void task4() {
    int n;
    cout << "\nЗадание 4. Модификация массива символов\n";
    cout << "Введите размер массива (n >= 5): ";
    cin >> n;

    if (n < 5) {
        cout << "Размер должен быть не менее 5.\n";
        return;
    }

    // Инициализация генератора ranlux24_base
    ranlux24_base gen(random_device{}());
    uniform_int_distribution<int> dist(33, 126); // диапазон видимых ASCII символов

    vector<char> chars(n);
    cout << "Исходный массив: [";
    for (int i = 0; i < n; ++i) {
        chars[i] = static_cast<char>(dist(gen));
        cout << chars[i];
        if (i != n - 1) cout << ", ";
    }
    cout << "]\n";

    // Сдвиг влево на 2 позиции
    rotate(chars.begin(), chars.begin() + 2, chars.end());

    cout << "Модифицированный массив: [";
    for (int i = 0; i < n; ++i) {
        cout << chars[i];
        if (i != n - 1) cout << ", ";
    }
    cout << "]\n\n";
}

// Задание 5: Сортировка и анализ цифр
void task5() {
    int n;
    cout << "Задание 5: Введите размер массива (n >= 10): ";
    cin >> n;
    while (n < 10) {
        cout << "Ошибка: n >= 10. Повторите: ";
        cin >> n;
    }

    uniform_int_distribution<> dist(100, 900);
    vector<int> arr(n);
    for (int& x : arr) x = dist(gen);

    cout << "Исходный массив:\n";
    for (int x : arr) cout << x << " ";
    cout << "\n";

    sort(arr.begin(), arr.end(), greater<int>()); // по убыванию

    cout << "Отсортированный по убыванию:\n";
    for (int x : arr) cout << x << " ";
    cout << "\n";

    // Подсчет цифр
    map<char, int> digitCount;
    for (int x : arr) {
        string s = to_string(x);
        for (char c : s) digitCount[c]++;
    }

    cout << "Частота каждой цифры в массиве:\n";
    for (const auto& [digit, count] : digitCount) {
        cout << digit << " — " << count << "\n";
    }
}

int main() {
    int n;
    cout << "Введите размер массива n (n >= 10): ";
    cin >> n;
    while (n < 10) {
        cout << "Ошибка: n >= 10. Повторите: ";
        cin >> n;
    }

    vector<int> arr;
    task1(arr, n);
    task2(arr);
    task3(arr);
    task4();
    task5();

    return 0;
}
