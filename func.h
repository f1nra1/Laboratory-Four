#ifndef FUNC_H
#define FUNC_H

enum class Method {
    Bisection = 1,
    Newton,
    Iteration
};

double f(double x);
double df(double x);
double phi(double x);

void bisection(double a, double b, double eps, int& iterations);
void newton(double x0, double eps, int& iterations);
void iteration(double x0, double eps, int& iterations);

#endif
