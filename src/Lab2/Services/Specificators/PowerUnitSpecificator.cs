namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class PowerUnitSpecificator
{
    protected internal PowerUnitSpecificator()
    {
        string str = string.Empty;
        PeakLoad = str;
        Name = str;
    }

    protected internal PowerUnitSpecificator(string peakLoad, string name)
    {
        PeakLoad = peakLoad;
        Name = name;
    }

    public string PeakLoad { get; set; }
    public string Name { get; set; }
}