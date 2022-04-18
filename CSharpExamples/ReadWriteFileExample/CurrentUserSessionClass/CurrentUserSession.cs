namespace CurrentUserSessionClass;
public class CurrentUserSession {
    //Fields
    private int _uid;
    private int _pid;

    //Constructor
    public CurrentUserSession(List<string> ls) {
        _uid = Int32.Parse(ls[0]);
        _pid = Int32.Parse(ls[1]);
    }

    //Properties
    public int pUid { get { return _uid; } }
    public int pPid { get { return _pid; } }
}
