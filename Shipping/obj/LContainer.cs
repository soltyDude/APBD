public class LContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LContainer(double height, double tareWeight, double depth, double maxPayload, string serialNumber, bool isHazardous)
        : base(height, tareWeight, depth, maxPayload, serialNumber)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        double capacityLimit = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (mass > capacityLimit)
        {
            NotifyHazard();
            throw new OverfillException("Attempting to load beyond safe capacity for liquid container.");
        }
        base.LoadCargo(mass);
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazardous situation in Liquid Container: {SerialNumber}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Liquid Container - Serial: {SerialNumber}, Hazardous: {IsHazardous}");
    }
}