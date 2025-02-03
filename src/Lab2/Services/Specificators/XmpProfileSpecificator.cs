namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class XmpProfileSpecificator
{
    protected internal XmpProfileSpecificator()
    {
        string str = string.Empty;
        Voltage = str;
        Frequency = str;
        Timing = str;
    }

    protected XmpProfileSpecificator(string timing, string voltage, string frequency)
    {
        Voltage = voltage;
        Frequency = frequency;
        Timing = timing;
    }

    public string Timing { get; set; }
    public string Voltage { get; set; }
    public string Frequency { get; set; }
}