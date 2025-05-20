#include <iostream>
#include <vector>
#include <map>
#include <string>
using namespace std;

// Возвращает индекс кандидата в предпочтениях избирателя
int indexOf(const vector<string>& ranking, const string& name) {
    for (int i = 0; i < ranking.size(); i++) {
        if (ranking[i] == name) return i;
    }
    return -1; // не найден
}

int main() {
    int n, k;
    cout << "Введите количество кандидатов: ";
    cin >> n;

    cout << "Введите количество избирателей: ";
    cin >> k;

    vector<string> candidates(n);
    cout << "Введите имена кандидатов:\n";
    for (int i = 0; i < n; ++i) {
        cin >> candidates[i];
    }

    vector<vector<string>> votes(k);
    cout << "\nВведите предпочтения избирателей (от первого до последнего кандидата):\n";
    for (int i = 0; i < k; ++i) {
        cout << "Избиратель #" << i + 1 << ": ";
        for (int j = 0; j < n; ++j) {
            string name;
            cin >> name;
            votes[i].push_back(name);
        }
    }

    // ===== Метод Борда =====
    map<string, int> bordaScores;
    for (const auto& vote : votes) {
        for (int i = 0; i < n; ++i) {
            bordaScores[vote[i]] += n - 1 - i;
        }
    }

    int maxScore = -1;
    vector<string> bordaWinners;
    for (const auto& [name, score] : bordaScores) {
        if (score > maxScore) {
            maxScore = score;
            bordaWinners = { name };
        } else if (score == maxScore) {
            bordaWinners.push_back(name);
        }
    }

    // ===== Метод Кондорсе =====
    map<string, int> condorcetWins;
    for (int i = 0; i < n; ++i) {
        string a = candidates[i];
        for (int j = 0; j < n; ++j) {
            if (i == j) continue;
            string b = candidates[j];
            int countA = 0, countB = 0;
            for (const auto& vote : votes) {
                if (indexOf(vote, a) < indexOf(vote, b))
                    countA++;
                else
                    countB++;
            }
            if (countA > countB)
                condorcetWins[a]++;
        }
    }

    vector<string> condorcetWinners;
    for (const auto& [name, wins] : condorcetWins) {
        if (wins == n - 1) {
            condorcetWinners.push_back(name);
        }
    }

    // ===== Результаты =====
    cout << "\n--- Результаты выборов ---" << endl;

    if (bordaWinners.size() == 1) {
        cout << "Победитель по методу Борда: " << bordaWinners[0]
             << " (баллы: " << bordaScores[bordaWinners[0]] << ")\n";
    } else {
        cout << "Метод Борда: Ничья между кандидатами: ";
        for (const auto& name : bordaWinners) {
            cout << name << " (баллы: " << bordaScores[name] << ") ";
        }
        cout << endl;
    }

    if (condorcetWinners.empty()) {
        cout << "Метод Кондорсе: Победителя не существует (циклические предпочтения)" << endl;
    } else if (condorcetWinners.size() == 1) {
        cout << "Победитель по методу Кондорсе: " << condorcetWinners[0] << endl;
    } else {
        cout << "Метод Кондорсе: Ничья между кандидатами: ";
        for (const auto& name : condorcetWinners) {
            cout << name << " ";
        }
        cout << endl;
    }

    // Комментарий
    if (bordaWinners.size() == 1 && condorcetWinners.size() == 1 &&
        bordaWinners[0] != condorcetWinners[0]) {
        cout << "\nМетоды Борда и Кондорсе дали разные результаты. "
                "Это возможно при сложных или циклических предпочтениях избирателей.\n";
    }

    return 0;
}
