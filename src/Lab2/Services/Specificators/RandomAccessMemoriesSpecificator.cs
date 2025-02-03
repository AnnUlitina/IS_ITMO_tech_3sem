using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class RandomAccessMemoriesSpecificator
{
    protected internal RandomAccessMemoriesSpecificator()
    {
        string str = string.Empty;
        FormFactor = str;
        AvailableMemorySizeAmount = str;
        PowerConsumption = str;
        Name = str;
        Pair = new List<string>();
        SupportedDdrStandardVersion = new List<string>();
    }

    protected internal RandomAccessMemoriesSpecificator(
        string availableMemorySizeAmount,
        string formFactor,
        IEnumerable<string> supportedDdrStandardVersion,
        string powerConsumption,
        string name,
        IEnumerable<string> pair)
    {
        FormFactor = formFactor;
        AvailableMemorySizeAmount = availableMemorySizeAmount;
        PowerConsumption = powerConsumption;
        Name = name;
        Pair = pair;
        SupportedDdrStandardVersion = supportedDdrStandardVersion;
    }

    public string AvailableMemorySizeAmount { get; set; }
    public string FormFactor { get; set; }
    public IEnumerable<string> SupportedDdrStandardVersion { get; set; }
    public string PowerConsumption { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> Pair { get; set; }
}