class CInInteger {      //Re-useable
    //delimiter for operands
    static char SPACE = ' ';
    //Ascii value for numbers range from 48 to 57 . comparable with operators
    static int MinHex = 48;         //Int32 MinHex = 0x30;  
    static int MaxHex = 57;         //Int32 MaxHex = 0x39;   
    private string? _INPUT = "";    //Place holder for Console.ReadLine()
    public List<int> _OPERANDS = new List<int>(); //dynamic array

    public CInInteger() {
        _INPUT = Console.ReadLine();
        if (_INPUT != null){
            fPhraseIntlist(_INPUT, _OPERANDS);   //assigning object to variable is similar to assgin object's pointer(address) to the variable.
        }
    }

    private int fSafeInt(string s)
    {
        int X = 0;
        try
        {
            X = Int32.Parse(s);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Exception:Parsed value > {0:E}.", int.MaxValue);
        }
        return X;
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
}
class GaussianSum {
    //fields
    private int _N = 0;
    //constructor
    public GaussianSum() {
        CInInteger cin = new CInInteger();
        _N = cin._OPERANDS[0];
    }

    //functions
    public int fGaussianSum() {
        int P = _N / 2;           //Pivot
        int X = _N + 1;           //sum of head and tail number
        if (_N % 2 == 0) {
            X *= P;             //(n+1) * n/2 
        }
        else {
            X = X * P + P + 1;          //(n+1) * n/2 + (n/2+1) 
        }
        return X;
    }
}

class Program {
    static void Main(string[] args) {
        GaussianSum X = new GaussianSum();
        Console.WriteLine(X.fGaussianSum());
    }
}
