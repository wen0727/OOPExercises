class CInInteger {   //Re-useable
    //delimiter for operands
    static char SPACE = ' ';
    //Ascii value for numbers range from 48 to 57 . comparable with operators
    static int MinHex = 48;         //Int32 MinHex = 0x30;  
    static int MaxHex = 57;         //Int32 MaxHex = 0x39;   
    static int INDEX = 0;
    private string? _INPUT = "";    //Place holder for Console.ReadLine()
    public List<int> _OPERANDS = new List<int>(); //dynamic array

    public CInInteger() {
        _INPUT = Console.ReadLine();
        if (_INPUT != null) {
            fPhraseIntlist(_INPUT, _OPERANDS);   //assigning object to variable is similar to assgin object's pointer(address) to the variable.
        }
    }

    private List<int> fPhraseIntlist(string s, List<int> ops) {
        string? OPERAND = "";
        for (int i = 0; i < s.Length; i++) {
            if (s[i] <= MaxHex && s[i] >= MinHex) {
                OPERAND += s[i];
                if (i == s.Length - 1) {
                    ops.Add(Int32.Parse(OPERAND));
                }
                continue;
            }
            if (s[i] == SPACE && OPERAND != "") {     //the condition allows multiple space
                ops.Add(Int32.Parse(OPERAND));
                OPERAND = "";
            }
        }
        return ops;
    }

    public int fCin() {
        int x = _OPERANDS[INDEX];
        INDEX += 1;
        return x;
    }
}

class GaussianSum {
    //fields
    private int _N = 0;
    //constructor
    public GaussianSum(int x) {
        _N = x;
    }

    //functions
    public int fGaussianSum() {
        int P = _N / 2;                 //Pivot
        int X = _N + 1;                 //sum of head and tail number
        if (_N % 2 == 0) {
            X *= P;                     //(n+1) * n/2 
        }
        else {
            X = X * P + P + 1;          //(n+1) * n/2 + (n/2+1) 
        }
        return X;
    }
}

class EvenSum {

    public EvenSum() {
    }

    public int fEvenSum(int n, int acc) {
        if (n > 0) {
            if (n % 2 == 0) {
                acc += n;
            }
            return fEvenSum(n - 1, acc);
        }
        return acc;
    }
}

class PrimeFactorization {
    public PrimeFactorization() { 
    }

    public void fPrimefactorize(int x, int y) {
        if (x % y == 0)
        {
            if (x == y)
            {
                Console.Write(y);
            }
            else
            {
                Console.Write("{0} * ", y);
                x /= y;
                fPrimefactorize(x, y);
            }
        } else {
            fPrimefactorize(x, y + 1);
        }    
    }
}

class Leibniz {
    public Leibniz() { 
    }

    public double fLeibniz(int n, double acc) {
        if (n > 0) {
            if (n % 2 == 0) {
                acc += 1.0 / (2 * n + 1);
            }
            else {
                acc -= 1.0 / (2 * n + 1);
            }
            return fLeibniz(n - 1, acc);
        } 
        if  (n == 0) {
            acc += 1;
        }
        return 4 * acc;

    }
}

class Program {
    static void Main(string[] args) {
        ////1. Gaussian sum.
        //CInInteger cin = new CInInteger();
        //int x = 0;
        //x = cin.fCin();

        //GaussianSum sum = new GaussianSum(x);
        //Console.WriteLine(sum.fGaussianSum());

        ////2. Even sum.
        //CInInteger cin = new CInInteger();
        //int y = 0;
        //y = cin.fCin();

        //EvenSum eSum = new EvenSum();
        //Console.WriteLine(eSum.fEvenSum(y, 0));

        ////3. Prime factorization.
        //CInInteger cin = new CInInteger();
        //int z = 0;
        //z = cin.fCin();

        //PrimeFactorization pf = new PrimeFactorization();
        //pf.fPrimefactorize(z, 2);

        //4. Lebniz formula
        CInInteger cin = new CInInteger();
        int t = 0;
        t = cin.fCin();
        Console.WriteLine(t);

        Leibniz l = new Leibniz();
        Console.WriteLine(l.fLeibniz(t,0.0));
        //double acc = 3.333;
        //int n = 1;

     
        //Console.WriteLine(n / acc);
    }
}
