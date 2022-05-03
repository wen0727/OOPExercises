// Exercise3.cpp : struct, scanf, ceil
//

#include <iostream>
#define arraySizeMax 100            //store 100 ascii values 
using namespace std;

struct Histogram {
    int _NINTERVAL;
    int _NDATA;
    int* _DATAS;
};
Histogram _HIST1;

int main() {

//    Histogram _HIST1;
    int INDEXI = 0;
    int NUMBER;
    int MAXDATA=0;

    //stdi -> int
    cin >> _HIST1._NINTERVAL;
    cin >> _HIST1._NDATA;

    //stdi -> _HIST1._NINTERVAL[_HIST1._NDATA]
    //int -> int
    //The loop can be make a function
    _HIST1._DATAS = (int*)malloc(arraySizeMax * sizeof(int));
    while (INDEXI < _HIST1._NDATA && scanf_s("%d", &NUMBER)) {                                                //scanf("%d", &VAR)    ==  int var; int* pvar; pvar=&VAR; *pvar = stdi , the function ends with enter
        if (NUMBER > MAXDATA) {
            MAXDATA = NUMBER;
        }
        _HIST1._DATAS[INDEXI] = NUMBER;
        cout << _HIST1._DATAS[INDEXI] << endl;
        //cout << &_HIST1._DATAS << endl;
        ++INDEXI;
    }
    //cout << MAXDATA << "MAX " << _HIST1._NINTERVAL << " INTERVAL" << endl;
    //cout << MAXDATA / _HIST1._NINTERVAL << endl;;=
    int INTERVAL = ceil( float (MAXDATA) / float (_HIST1._NINTERVAL));
    //cout << float(MAXDATA) / float(_HIST1._NINTERVAL) << endl;
    
    ////The following should be made as a function: int array -> std out
    if (_HIST1._DATAS != NULL) {
    for (int i = 1; i < _HIST1._NINTERVAL+1; i++) {
        int INTERVARMAX = i * INTERVAL;
        int INTERVARMIN = (i - 1) * INTERVAL;
        int COUNT = 0;
        for (int j = 0; j < _HIST1._NDATA; j++) {
            if (INTERVARMIN <= _HIST1._DATAS[j] && _HIST1._DATAS[j] < INTERVARMAX) {
                COUNT += 1;
            }
        }
        cout << INTERVARMIN << ": " << COUNT << endl;
    }
}

    _HIST1._DATAS = NULL;
    free(_HIST1._DATAS);                                                                                        //free the CHAR ARRAY
    return 0;
}












////Exercise3.cpp : struct, array, pointer, malloc(), free()
////stream texts 
//
//#include <iostream>
//#include <stdio.h>
//#define intDigitMax 10
//#define dataArrayMax 100            //store 100 ascii values 
//#define intAsciiArrayMax 32            //store 100 ascii values 
//#define space ' '
//#define linefeed '\n'
//#define ascii0 47
//#define ascii9 58
//using namespace std;
//
//struct Histogram {
//    int _NINTERVALS;
//    int _NDATA;
//    char* _DATA;
//    int* _DATAS;
//};
//
//
//int main() {
//    Histogram _HIST1;
//    int PDATALENGTH = 0;
//    char ASCIIVALUE;;
//
//    _HIST1._DATAS = (int*)malloc(dataArrayMax * sizeof(int));
//
//    do {
//        ASCIIVALUE = getchar();             //Read at least one ASCII
//        ////matcing the patterns for putting CHARS to CHAR ARRAY
//        _HIST1._DATA = (char*)malloc(intAsciiArrayMax * sizeof(char));                  //create new memory space and point to that space as whole, which should be indexed by length of the pointer not with ++ or -- same as char array e.g char* arra = new char[SIZE]         
//        int PDATAINDEX = 0;
//        while (ascii0 < ASCIIVALUE && ASCIIVALUE < ascii9 && ASCIIVALUE != space) {
//            _HIST1._DATA[PDATAINDEX] = ASCIIVALUE;                                      //assign determinded value into current address of the CHAR ARRAY
//            cout << _HIST1._DATA[PDATAINDEX] << endl;
//            cout << &_HIST1._DATA << endl;
//            ++PDATAINDEX;                                                               //it is possible to exeed the array boundary
//            ASCIIVALUE = getchar();                                                     //get new ASCII value from Console 
//        }
//        ////char array -> int 
//        if (_HIST1._DATA != NULL) {
//            _HIST1._DATAS[PDATALENGTH] = 0;
//            for (int i = 0; i < PDATAINDEX; i++) {                                      //fCharArrayToInt
//                //cout << _HIST1._DATA[i] << "st digit" << endl;
//                double NUM = 0;
//                NUM = _HIST1._DATA[i] - 48;
//                //cout << NUM << "digit" << endl;
//                //cout << NUM*pow(10, PDATAINDEX-i-1) << "digit" << endl;
//                _HIST1._DATAS[PDATALENGTH] += NUM * pow(10, PDATAINDEX - i - 1);
//            }
//            cout << _HIST1._DATAS[PDATALENGTH] << endl;
//        }
//        _HIST1._DATA = NULL;
//        free(_HIST1._DATA);                                                         //free the CHAR ARRAY
//        ++PDATALENGTH;
//
//    } while (ASCIIVALUE != linefeed);                                               //Existing condition
//    _HIST1._DATAS = NULL;
//    free(_HIST1._DATAS);                                                            //free the CHAR ARRAY
//    return 0;
//}















