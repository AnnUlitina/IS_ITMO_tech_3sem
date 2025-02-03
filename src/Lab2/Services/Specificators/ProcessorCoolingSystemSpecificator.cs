using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class ProcessorCoolingSystemSpecificator
{
    protected internal ProcessorCoolingSystemSpecificator()
    {
        string str = string.Empty;
        ThermalDesignPower = str;
        SupportedSockets = new List<string>();
        OverallDimensions = str;
        Name = str;
    }

    protected internal ProcessorCoolingSystemSpecificator(
        string thermalDesignPower,
        IEnumerable<string> supportedSockets,
        string overallDimensions,
        string name)
    {
        ThermalDesignPower = thermalDesignPower;
        SupportedSockets = supportedSockets;
        OverallDimensions = overallDimensions;
        Name = name;
    }

    public string ThermalDesignPower { get; set; }
    public IEnumerable<string> SupportedSockets { get; set; }
    public string OverallDimensions { get; set; }
    public string Name { get; set; }
}