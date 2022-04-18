namespace CustomerClass;
using System.Collections.Immutable;
using CinIntegerClass;

public class Customer {
    private int _id;                                        //need to change to string
    private string _name;                       
    private ImmutableList<int> _viewedPids;                 //need to change to list of string
    private ImmutableList<int> _purchasedPids;              //need to change to list of string

    public Customer(List<string> ls) {
        _id = Int32.Parse(ls[0]);
        _name = ls[1];
        CinInteger CIN1 = new CinInteger(ls[2]);
        _viewedPids = CIN1.pOperands.ToImmutableList();
        CinInteger CIN2 = new CinInteger(ls[3]);
        _purchasedPids = CIN2.pOperands.ToImmutableList();
    }

    public int pId { get { return _id; } }
    public string pName { get { return _name; } }
    public ImmutableList<int> pViewedPids { get { return _viewedPids; } }
    public ImmutableList<int> pPurchasedPids { get { return _viewedPids; } }

    private string fIntPids(ImmutableList<int> pids) {
        string PIDS = "";
        for (int i = 0; i < pids.Count-1; i++) {
            if (i == pids.Count-2) {
                PIDS += pids[i].ToString();
            } else {
                PIDS += pids[i].ToString() + " ";
            }
        }
        return PIDS;
    } //
    public override string ToString() {
        return _id.ToString() + " " + _name.ToString() + " " + fIntPids(_viewedPids) + " | " + fIntPids(_purchasedPids); 
    }
}
