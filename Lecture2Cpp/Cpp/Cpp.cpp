// Cpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
//Gaussian sum
int fGaussian(int n) {
	int pivot = 0;
	int X = n+1;
	if (n % 2 == 0) {
		pivot = n / 2;
		X *= pivot;
	} else {
		pivot = n / 2;
		X = X * pivot + pivot + 1;
	}
	return X;
}
//Sum of even numbers from 0 to n
int fEvenSum(int n, int acc) {	
	if (n > 0) {
		if (n % 2 == 0) {
			acc += n;
		} 
		return fEvenSum(n - 1, acc);
	}
	return acc;
}
//Prime factorization, more efficient algorithm exists such as no integer between 2 to square root n divides n
void fPrimeFactorize(int x, int y) {
		if (x % y == 0) {
			if (x == y) {
				cout << y;
			}
			else {
				cout << y << " * ";
				x /= y;
				fPrimeFactorize(x, y);
			}
		} else {
			fPrimeFactorize(x, y + 1);
		}
}
//Pi approximation from Leibniz.
double fLeibniz(int n, double acc) {
	if (n > 0) {
		if (n % 2 == 0) {
			acc += 1.0 / (2 * n + 1);
		}
		else {
			acc += -1.0 / (2 * n + 1);
		}
		return fLeibniz(n - 1, acc);
	}
	if (n == 0) {
		acc += 1.0;
	}
	return 4*acc;
}

int main()
{
	////1. Gaussian Sum
	//int n = 0;
	//cin >> n;
	//cout << fGaussian(n) <<endl;;
	
	////2. Eeven sum
	//int m = 0;
	//cin >> m;
	//cout << fEvenSum(m,0);

	////Prime Factorization.
	//int z = 0;
	//cin >> z;
	//fPrimeFactorize(z,2);

	////Approximimating pi, Leibniz formula
	int p = 0;
	cin >> p;
	cout << fLeibniz(p,0.0) << endl;
}
