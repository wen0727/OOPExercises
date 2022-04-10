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

class Compare2Int { 
    //static char EOS = '\0';     //C# does not have end of string '\0'
    //delimiter for operands
    static char SPACE = ' ';
    //Ascii value for numbers range from 48 to 57 . comparable with operators
    static int MinHex = 48;    //Int32 MinHex = 0x30;  
    static int MaxHex = 57;    //Int32 MaxHex = 0x39;    
    
    private int _X = 0;
    private int _Y = 0;
    private string? _INPUT = "";
    private List<int> _OPERANDS = new List<int>(); //dynamic array

    public Compare2Int() { 
        _INPUT = Console.ReadLine(); 
        if (_INPUT != null) {
            fPhraseIntlist(_INPUT,_OPERANDS);   //assigning object to variable is similar to assgin object's pointer(address) to the variable.
            _X = _OPERANDS[0];  
            _Y = _OPERANDS[1];
        }
            
    }
    private int fSafeInt (string s) { 
        int X = 0;
        try { 
            X = Int32.Parse(s);
        }
        catch (OverflowException){
            Console.WriteLine("Exception:Parsed value > {0:E}.", int.MaxValue);
        }
        return X;
    }
    private List<int> fPhraseIntlist (string s, List<int> ops) { //when return a value compare to assignment 
        string? OPERAND = "";
        for (int i = 0; i < s.Length; i++) { 
            if (s[i]<=MaxHex && s[i]>=MinHex) { 
                OPERAND += s[i];
                if (i == s.Length - 1) { 
                    ops.Add(Int32.Parse(OPERAND));
                    //ops.Add(fSafeInt(OPERAND));
                }
                continue;
            }
            if (s[i]==SPACE && OPERAND != "") {     //the condition allows multiple space
                ops.Add(Int32.Parse(OPERAND));
                //ops.Add(fSafeInt(OPERAND));
                OPERAND="";
                }
            }            
        return ops;
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
    //static char EOS = '\0';     //C# does not have end of string '\0'
    //delimiter for operands
    static char SPACE = ' ';
    //Ascii value for numbers range from 48 to 57 . comparable with operators
    static int MinHex = 48;    //Int32 MinHex = 0x30;  
    static int MaxHex = 57;    //Int32 MaxHex = 0x39;    
    
    private int _X = 0;
    private int _Y = 0;
    private int _Z = 0;
    private string? _INPUT = "";
    private List<int> _OPERANDS = new List<int>(); //dynamic array

    public XplusYminusZ() { 
        _INPUT = Console.ReadLine(); 
        if (_INPUT != null) {
            fPhraseIntlist(_INPUT,_OPERANDS);   //assigning object to variable is similar to assgin object's pointer(address) to the variable.
            _X = _OPERANDS[0];  
            _Y = _OPERANDS[1];
            _Z = _OPERANDS[2];
        }
            
    }
    private int fSafeInt (string s) { 
        int X = 0;
        try { 
            X = Int32.Parse(s);
        }
        catch (OverflowException){
            Console.WriteLine("Exception:Parsed value > {0:E}.", int.MaxValue);
        }
        return X;
    }
    private List<int> fPhraseIntlist (string s, List<int> ops) { //when return a value compare to assignment 
        string? OPERAND = "";
        for (int i = 0; i < s.Length; i++) { 
            if (s[i]<=MaxHex && s[i]>=MinHex) { 
                OPERAND += s[i];
                if (i == s.Length - 1) { 
                    ops.Add(Int32.Parse(OPERAND));
                    //ops.Add(fSafeInt(OPERAND));
                }
                continue;
            }
            if (s[i]==SPACE && OPERAND != "") {     //the condition allows multiple space
                ops.Add(Int32.Parse(OPERAND));
                //ops.Add(fSafeInt(OPERAND));
                OPERAND="";
                }
            }            
        return ops;
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

