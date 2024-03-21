public abstract class Container
{
    public double CargoMass { get; set; }
    public double Height { get; }
    public double TareWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxPayload { get; }

    protected Container(double height, double tareWeight, double depth, double maxPayload, string serialNumber)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
        SerialNumber = serialNumber;
        CargoMass = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass > MaxPayload)
        {
            throw new OverfillException("Cargo mass exceeds container capacity.");
        }
        CargoMass = mass;
    }

    public virtual void EmptyCargo()
    {
        CargoMass = 0;
    }

    public abstract void PrintInfo();
}