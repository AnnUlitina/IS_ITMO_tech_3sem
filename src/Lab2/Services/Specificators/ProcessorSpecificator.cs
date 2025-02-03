using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class ProcessorSpecificator
{
    protected internal ProcessorSpecificator()
    {
        string? str = string.Empty;
        Name = str;
        CoreFrequency = str;
        CoreCount = str;
        Socket = str;
        EmbeddedVideoCore = str;
        SupportedMemoryFrequencies = new List<string>();
        ThermalDesignPower = str;
        PowerConsumption = str;
    }

    protected internal ProcessorSpecificator(
        string name,
        string coreFrequency,
        string coreCount,
        string socket,
        string embeddedVideoCore,
        IEnumerable<string> supportedMemoryFrequencies,
        string thermalDesignPower,
        string powerConsumption)
    {
        Name = name;
        CoreFrequency = coreFrequency;
        CoreCount = coreCount;
        Socket = socket;
        EmbeddedVideoCore = embeddedVideoCore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public string CoreFrequency { get; set; }
    public string CoreCount { get; set; }
    public string Socket { get; set; }
    public string EmbeddedVideoCore { get; set; }
    public IEnumerable<string> SupportedMemoryFrequencies { get; set; }
    public string ThermalDesignPower { get; set; }
    public string PowerConsumption { get; set; }
}