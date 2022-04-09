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
    public string fName { 
        get { return "Hello " + _NAME + "!"; }
    }
}

class Program { 
    static void Main(string[] args) {
        //Hello World!
        HelloWorld X = new HelloWorld();
        Console.WriteLine(X.fName);
        //Hello NAME!
        HelloName Y = new HelloName();
        Console.WriteLine(Y.fName);
        
    }
}

