// Cpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;//for std::cin, std::string and so on
void fHelloWorld() {
    cout << "Hello World!\n";
}

void fHelloName() {
    string NAME;
    cin >> NAME;
    cout << "Hello " << NAME << "!" << endl;
}
void fCompareTwoInt() {
    int X = 0;
    int Y = 0;
    cin >> X >> Y;
    if (X == Y) {
        cout << "x is equal to y" << endl;
    }else if (X > Y) {
        cout << "x is larger to y" << endl;
    } else {
        cout << "x is smaller to y" << endl;
    }
}

void fXplusYminusZ() {
    int X = 0;
    int Y = 0;
    int Z = 0;
    cin >> X >> Y >> Z;
    cout << X + Y - Z << endl;
}

int main() {
    //Hello World!
    fHelloWorld();  
    fHelloName();
    fCompareTwoInt();
    fXplusYminusZ();
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
