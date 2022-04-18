namespace ContentReaderClass;

public class ContentReader {
    //delimiter char
    static char comma = ',';
    //ignore char
    static char space = ' ';
    //Ascii value range for alphabet and numbers
    static int minAsciiReg = 20;
    static int maxAsciiReg = 126;
    private int _index = 0;
    private List<string> _CONTENT = new List<string>();

    public ContentReader(string? input) {
        if (input != null) {
            fPhraseContent(input, _CONTENT);
        }
    }

    public List<string> pContent { get { return _CONTENT; } }

    private List<string> fPhraseContent(string s, List<string> ls) {
        string? WORD = "";
        for (int i = 0; i < s.Length; i++) {
            if (minAsciiReg <= s[i] && s[i] <= maxAsciiReg && s[i] != comma) {
                if (s[i] == space && WORD == "") {  //one or more space before a valid reg
                    continue;
                }
                WORD += s[i];                       //one or more char for valid reg
                if (i == s.Length - 1) {            //string end
                    ls.Add(WORD);
                }
            }
            if (s[i] == comma) {
                ls.Add(WORD);
                WORD = "";
            }
        }
        return ls;
    }

    public string fReadOne() {
        string s = _CONTENT[_index];
        _index += 1;
        return s;
    }
}
