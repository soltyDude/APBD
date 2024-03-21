public interface IHazardNotifier
{
    void NotifyHazard();
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}