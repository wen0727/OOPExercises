namespace ProductClass;

public class Product {
    //Fields
    static string space = " ";
    private int _id;                //col 0
    private string _name;          //col 1
    private int _year;              //col 2
    private string[] _keyWords = new string[5];   //col 3,4,5,6,7,
    private float _reviewRank;      //col 8
    private int _price;             //col 9

    //Constructor
    public Product() {}
    public Product(List<string> ls) {
        _id = Int32.Parse(ls[0]);
        _name = ls[1];
        _year = Int32.Parse(ls[2]);
        for (int i=0 ; i < 5; i++) {
            _keyWords[i] = ls[i + 3];
        }
        _reviewRank = float.Parse(ls[8]);
        _price = Int32.Parse(ls[9]);
    }
    //Properties
    public int pID { get { return _id; } }
    public string pName { get { return _name; } }
    public int pYear { get { return _year; } }
    public string[] pKeyWords { get { return _keyWords; } }
    public float pReviewRank { get { return _reviewRank; } }
    public int pPrice { get { return _price; } }

    //Functions
    //  The function can be used for concaternating the key words and trimming the space(empty keywords);
    private string fKeyWords (string[] kws) { 
        string KEYWORDS="";
        for (int i=0; i<kws.Length-1; i++) { 
            if (kws[i] == " ") {
                continue;
            } else {
                if (i == kws.Length-2) { 
                    KEYWORDS += kws[i];
                } else { 
                    KEYWORDS += kws[i] + " ";
                }
            }
        }
        return KEYWORDS;
    }
    
    //Overriden functions
    //Console output format.
    public override string ToString(){
        return _id.ToString() + space + _name + space + _year + space + fKeyWords(_keyWords) + space + _reviewRank.ToString() + space + _price;
    }

}
