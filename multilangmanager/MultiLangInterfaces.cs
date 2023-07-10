public interface IMultiLangObserver
{
    void OnNotify();
}

public interface IMultiLangSubject
{
    public void AddObserver(IMultiLangObserver observer);
    public void RemoveObserver(IMultiLangObserver observer);
    public void Notify();
}
