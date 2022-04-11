class HelloWorld {
    static string _NAME = "Hello World!"; //static, defines that memory address is shared among all instances of the class
    public HelloWorld() { }
                                          //Empty constructor because the field has been initialized with value
    
    public string fName { 
        get { return _NAME; }             //no setter for fields because of the constructor
    }                                     //property, get and set fileds
}

class HelloName {
    string _NAME = "0";  //field is not static, because we don't have any value share amoung the instances.
    string? INPUT = "";
    public HelloName() {
        INPUT = Console.ReadLine();
        if (INPUT != null) { 
            _NAME = INPUT;
        }
    }
    public string fName() {           //function
        return "Hello " + _NAME + "!";
    }
}

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
                    //ops.Add(fSafeInt(OPERAND));
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

class Compare2Int { 
    private int _X = 0;
    private int _Y = 0;
    
    public Compare2Int() { 
        CInInteger cin = new CInInteger();
        _X = cin._OPERANDS[0];
        _Y = cin._OPERANDS[1];
    }

    public string fCompare() {
        if (_X == _Y) { 
            return "x is equal to y.";
        } else if (_X > _Y) { 
            return "x is larger than y.";
        } else { 
            return "x is smaller to y.";
        }
    }
}

class XplusYminusZ { 
    private int _X = 0;
    private int _Y = 0;
    private int _Z = 0;

    public XplusYminusZ() {
        CInInteger cin = new CInInteger();
        _X = cin._OPERANDS[0];  
        _Y = cin._OPERANDS[1];
        _Z = cin._OPERANDS[2];     
    }

    public int fXplusYminusZ() {
        int result = _X + _Y - _Z;
        return result;
    }
}


class Program { 
    static void Main(string[] args) {
        //1.Hello World!
        //HelloWorld X = new HelloWorld();
        //Console.WriteLine(X.fName);
        //2.Hello NAME!
        //HelloName Y = new HelloName();
        //Console.WriteLine(Y.fName());
        //3.Bigger number
        //Compare2Int Z = new Compare2Int();
        //Console.WriteLine(Z.fCompare());        
        //4.x+y-z
        XplusYminusZ W = new XplusYminusZ();
        Console.WriteLine("The solution is {0}.", W.fXplusYminusZ());
    }
}

