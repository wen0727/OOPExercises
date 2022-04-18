namespace CinIntegerClass;
public class CinInteger {
    //delimiter for operands
    static int semicolon = 59;
    //Ascii value for numbers range from 48 to 57 . comparable with operators
    static int minAsciiNum = 48;         //Int32 MinHex = 0x30;  
    static int maxAsciiNum = 57;         //Int32 MaxHex = 0x39;   
    private List<int> _OPERANDS = new List<int>();

    public CinInteger(string input) {        
        if (input != null) {
            fPhraseIntlist(input, _OPERANDS);                       //assigning object to variable is similar to assgin object's pointer(address) to the variable.
        }
    }
    
    public List<int> pOperands { get { return _OPERANDS; } }

    private List<int> fPhraseIntlist(string s, List<int> ops) {     //works only for semicolon
        string? OPERAND = "";
        for (int i = 0; i < s.Length; i++) {
            if (s[i] <= maxAsciiNum && s[i] >= minAsciiNum && s[i] != semicolon) {
                OPERAND += s[i];
                if (i == s.Length - 1) {
                    ops.Add(Int32.Parse(OPERAND));
                }
            }
            if (s[i] == semicolon) {     //the condition allows multiple space
                ops.Add(Int32.Parse(OPERAND));
                OPERAND = "";
            }
        }
        return ops;
    }
}
