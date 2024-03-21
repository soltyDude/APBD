public abstract class Container
{
    private double _massNow; // kg
    private double _height; // cm
    private double _massMy; // kg the weight of the container itself, in kilograms
    private double _depth; // cm
    private string _sNumber;
    private double _massMax; // kg

    // Constructor
    protected Container(double massNow, double height, double massMy, double depth, double massMax, ref int s_num_counter)
    {
        _massNow = massNow;
        _height = height;
        _massMy = massMy;
        _depth = depth;
        _massMax = massMax;

        _sNumber = set_sNumber(s_num_counter);
        
        s_num_counter++;

    }

    // Getter and setter for _massNow
    public double MassNow
    {
        get { return _massNow; }
        set { _massNow = value; }
    }

    // Getter and setter for _height
    public double Height
    {
        get { return _height; }
        set { _height = value; }
    }

    // Getter and setter for _massMy
    public double MassMy
    {
        get { return _massMy; }
        set { _massMy = value; }
    }

    // Getter and setter for _depth
    public double Depth
    {
        get { return _depth; }
        set { _depth = value; }
    }

    // Getter and setter for _massMax
    public double MassMax
    {
        get { return _massMax; }
        set { _massMax = value; }
    }

    private String set_sNumber(int counte)
    {
        String sNumber = "";
        char firstLetter = this.GetType().Name[0];
        sNumber = $"{firstLetter}_container_{counte}";
        return sNumber;
    }

    public String get_sNumber()
    {
        return _sNumber;
    }
}