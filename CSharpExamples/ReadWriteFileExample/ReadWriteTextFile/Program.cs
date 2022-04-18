/*
The following examples is done by learning from https://docs.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/general/read-write-text-file#read-a-text-file .

key words C# Read Write Text file
 */
using System.IO;
using System.Collections.Immutable;
//using Microsoft.FSharp.Collections;

using ProductClass;
using ContentReaderClass;
using CurrentUserSessionClass;
using CustomerClass;


class Script {
    static void Main(string[] args) {
        //File -> Product list
        //Relative path
        string dataFile1 = @"data\Products.txt";
        
        //Pass file to StreamReader object
        StreamReader _SR = new StreamReader(dataFile1);
        string? _LINE1;     
        List<Product> _PRODUCTS = new List<Product>(); 
        //Read file untill reach the end of the file
        try {
            do {
                _LINE1 = _SR.ReadLine();
                //Console.WriteLine(_LINE1);
                ContentReader _CR = new ContentReader(_LINE1);
                Product _P = new Product(_CR.pContent);                  
                _PRODUCTS.Add(_P);
            } while (!_SR.EndOfStream);
        }
        catch (Exception e) {
            Console.WriteLine("Exception1:" + e.Message);
        }
        finally {
            //Close the file
            _SR.Close();
            Console.WriteLine("File1 closed.");
        }
        //Immutable Product list
        ImmutableList<Product> _products = _PRODUCTS.ToImmutableList();
        /*
        foreach (Product p in _products) { 
            Console.WriteLine(p);
        }
        */
        //Simple query on the Product list, which shows products in decending order
        
        var _qReviewRank = from p in _products
                           orderby p.pReviewRank descending
                           select p;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("An example shows the file input is successfully converted to modeled data.******************");
        Console.WriteLine("");
        foreach (Product p in _qReviewRank) {
            Console.WriteLine(p.ToString());
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("The first example ends.**********************************************************************");
        Console.WriteLine("");
        Console.WriteLine("");
        //Requirement 1.1 Recommendation by prchused rate
        //Relative path
        string dataFile2 = @"data\Users.txt";
        
        //Pass file to StreamReader object
        StreamReader _SR2 = new StreamReader(dataFile2);
        string? _LINE2;   
        List<Customer> _CS = new List<Customer>();
        //Read file untill reach the end of the file
        try {
            do {
                _LINE2 = _SR2.ReadLine();
                //Console.WriteLine(_LINE1);
                ContentReader _CR2 = new ContentReader(_LINE2);
                Customer _CUSTOMER = new Customer(_CR2.pContent);
                _CS.Add(_CUSTOMER);
            } while (!_SR2.EndOfStream);
        }
        catch (Exception e) {
            Console.WriteLine("Exception2:" + e.Message);
        }
        finally {
            //Close the file
            _SR2.Close();
            Console.WriteLine("File2 closed.");
        }
        
        ImmutableList<Customer> _cs = _CS.ToImmutableList();
        /*
        foreach (Customer c in _cs) { 
            Console.WriteLine(c);
        }
        */

        //pid -> (pId*Count) List
        ImmutableList<(int,int)> fPidToPidCountPair(ImmutableList<int> pids, ImmutableList<(int,int)> acc) { 
            if (pids.IsEmpty) { 
                return acc; 
            } else { 
                return fPidToPidCountPair(pids.Remove(pids[0]),acc.Add((pids[0],1)));
            }
        }
        
        //fInsert: pid -> count -> (pid*count) list -> (pid*count) list -> (pid*count) list
        ImmutableList<(int,int)> fInsertMultiset(int pid, int count, ImmutableList<(int,int)> ms, ImmutableList<(int,int)> acc) { 
            if (ms.IsEmpty) {
                return acc.Add((pid,count));
            } else { 
                if (pid == ms[0].Item1) { 
                    return fInsertMultiset(pid, count, ms.Remove(ms[0]), acc.Add((pid, count + ms[0].Item2)));
                } else {
                    return fInsertMultiset(pid, count, ms.Remove(ms[0]), acc.Add((ms[0].Item1,ms[0].Item2)));
                }
            }
        }
        
        /*  Test for inserting element to multi set.
        var _TEST1 = fPidToPidCountPair(_cs[0].pViewedPids,ImmutableList<(int,int)>.Empty);
        foreach ((int,int) ms in _TEST1) { 
            Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }
        var _TEST2 = fInsertMultiset(6, 1, _TEST1, ImmutableList<(int,int)>.Empty);
        foreach ((int,int) ms in _TEST2) { 
            Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }
        */
        
        //pNegExist: pid -> (pid*count) -> bool -> bool     // predicates, a key not exist in a multi-set
        bool pNegExist(int pid, ImmutableList<(int,int)> ms, bool acc) {
            if (ms.IsEmpty) { 
                return acc &= true;
            } else { 
                return  pNegExist(pid, ms.Remove(ms[0]), (acc &= ms[0].Item1 != pid));
            }
        }

        //fUnionTwoMultiSets: (pId*Count) List -> (pId*Count) List -> (pId*Count) List   // union of two multi-sets
        ImmutableList<(int,int)> fUnionTwoMultiSets(ImmutableList<(int,int)> ms, ImmutableList<(int,int)> acc) { 
            if (ms.IsEmpty) { 
                return acc;
            } else {
                if (pNegExist(ms[0].Item1, acc, true)) { 
                    return fUnionTwoMultiSets(ms.Remove(ms[0]),acc.Add((ms[0].Item1, ms[0].Item2)));
                } else { 
                    return fUnionTwoMultiSets(ms.Remove(ms[0]),fInsertMultiset(ms[0].Item1, ms[0].Item2, acc, ImmutableList<(int,int)>.Empty));
                }
            }
        }
        
        //fUsersViewedMultisets:Customer -> (pId*Count) List        
        ImmutableList<(int,int)> fUsersViewedMultisets(ImmutableList<Customer> cs, ImmutableList<(int,int)> acc) { 
            if (cs.IsEmpty) { 
                return acc;
            } else { 
                return fUsersViewedMultisets(cs.Remove(cs[0]), fUnionTwoMultiSets(fPidToPidCountPair(cs[0].pViewedPids,ImmutableList<(int,int)>.Empty),acc));
            }
        }

        /* Test for fUnionTwoMultiSets function
        var _TEST4 = fPidToPidCountPair(_cs[0].pViewedPids,ImmutableList<(int,int)>.Empty);
        foreach ((int,int) ms in _TEST4) { 
            Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }
        
        var _TEST5 = fPidToPidCountPair(_cs[0].pViewedPids,ImmutableList<(int,int)>.Empty);
        foreach ((int,int) ms in _TEST5) { 
            Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }

        var _TEST3 = fUnionTwoMultiSets(_TEST4,_TEST5);
        foreach ((int,int) ms in _TEST3) {
            Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }
        */

        //create a multisets of customer viewed products from all users 
        var _qViewedPids = fUsersViewedMultisets(_cs, ImmutableList<(int,int)>.Empty);
        /*
        foreach ((int,int) ms in _qReconnByViewed) { 
           Console.WriteLine(ms.Item1.ToString() + " " + ms.Item2.ToString());
        }
         */
        var _qrecommendedbyViewRate = from ms in _qViewedPids
                                      where ms.Item2 > 1
                                      orderby ms.Item2 descending
                                      join ps in _products on ms.Item1 equals ps.pID
                                      select ps;

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Requiremtn 1.1******************************************************************");
        Console.WriteLine("The frequently viewed films are listed as follows:");
        Console.WriteLine("");
        Console.WriteLine("");
        foreach (Product p in _qrecommendedbyViewRate){
            Console.WriteLine(p.pName);
        }

        Console.WriteLine("");
        Console.WriteLine("Solution for requirement 1.1 ends************************************************");
        Console.WriteLine("");
        
        // Requirement 1.2
        ImmutableList<(int,int)> fUsersPurchasedMultisets(ImmutableList<Customer> cs, ImmutableList<(int,int)> acc) { 
            if (cs.IsEmpty) { 
                return acc;
            } else { 
                return fUsersPurchasedMultisets(cs.Remove(cs[0]), fUnionTwoMultiSets(fPidToPidCountPair(cs[0].pPurchasedPids,ImmutableList<(int,int)>.Empty),acc));
            }
        }

        var _qPurchasedPids = fUsersPurchasedMultisets(_cs, ImmutableList<(int,int)>.Empty);
        var _qrecommendedbyPurchaseRate = from ms in _qPurchasedPids
                                          where ms.Item2 > 1
                                          orderby ms.Item2 descending
                                          join ps in _products on ms.Item1 equals ps.pID
                                          select ps;

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Requirement 1.2***************************************************************************************");
        Console.WriteLine("The frequently sold films are listed as follows:");
        Console.WriteLine("");
        Console.WriteLine("");
        foreach (Product p in _qrecommendedbyPurchaseRate){
            Console.WriteLine(p.pName);
        }

        Console.WriteLine("");
        Console.WriteLine("Solution for requirement 1.2 ends**************************************************************************");
        Console.WriteLine("");
        

        //Requirement 2.
        string dataFile3 = @"data\CurrentUserSession.txt";
        StreamReader _SR3 = new StreamReader(dataFile3);
        string? _LINE3;
        List<CurrentUserSession> _CURRENTUSERSESSION = new List<CurrentUserSession>();
        try {
            do {
                _LINE3 = _SR3.ReadLine();
                //Console.WriteLine(_LINE3);
                ContentReader _CR3 = new ContentReader(_LINE3);
                CurrentUserSession _CUS = new CurrentUserSession(_CR3.pContent);                  
                _CURRENTUSERSESSION.Add(_CUS);
            } while (!_SR3.EndOfStream);
        }
        catch (Exception e) {
            Console.WriteLine("Exception3:" + e.Message);
        }
        finally {
            //Close the file
            _SR3.Close();
            Console.WriteLine("File3 closed.");
        }
        //CurrentUserSession list
        ImmutableList<CurrentUserSession> _cus = _CURRENTUSERSESSION.ToImmutableList();
        //fExistsKW: string array -> string array -> bool   //predicates, key words matches
        bool fExistsKW(string[] kws1, string[] kws2) {
            bool EXISTS = false; 
            foreach (string kw in kws1) { 
                if (kw=="") { 
                    EXISTS |= false;
                } else { 
                    EXISTS |= kws2.Contains(kw);
                }
            }
            return EXISTS;
        }
        
        //fMatchProductByKeyWords: string array -> (fExistsKW: bool ) -> Product list -> Product list
        ImmutableList<Product> fMatchProductByKeyWords(string[] kws, ImmutableList<Product> ps, ImmutableList<Product> acc) { 
            if (ps.IsEmpty) { 
                return acc;
            } else { 
                if (fExistsKW(kws,ps[0].pKeyWords)) {
                    return fMatchProductByKeyWords(kws,ps.Remove(ps[0]),acc.Add(ps[0]));
                } else { 
                    return fMatchProductByKeyWords(kws,ps.Remove(ps[0]),acc);
                }
            }
        }
        //fFindKeyWords : pid -> Product list -> string array
        string[] fFindKeyWords(int pid, ImmutableList<Product> ps) { 
            if(ps.IsEmpty) { 
                return null;
            } else { 
                if (pid == ps[0].pID) { 
                    return ps[0].pKeyWords;
                } else { 
                    return fFindKeyWords(pid, ps.Remove(ps[0]));
                }    
            }
        }
        //fFindProductBySession : CurrentUserSession list -> Product list -> (fMatchProductByKeyWords: Product list) -> Product list
        ImmutableList<Product> fFindProductBySession(ImmutableList<CurrentUserSession> cuss, ImmutableList<Product> ps, ImmutableList<Product> acc) { 
            if(cuss.IsEmpty) { 
                return acc;
            } else { 
                return fFindProductBySession(cuss.Remove(cuss[0]), ps, fMatchProductByKeyWords(fFindKeyWords(cuss[0].pPid,ps),ps,acc));
            }
        }
        var _qProductsInSession = fFindProductBySession(_cus,_products,ImmutableList<Product>.Empty);

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Requirement 2************************************************************************");
        Console.WriteLine("Each session's recommendation is listed as follows.");
        Console.WriteLine("");
        Console.WriteLine("");
        foreach(Product p in _qProductsInSession) {
            Console.WriteLine(p);
        }
        Console.WriteLine("");
        Console.WriteLine("Solution for requiment 2 ends**************************************************************");
        
    }
}

