using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class BiosSpecificator
{
    protected internal BiosSpecificator()
    {
        string str = string.Empty;
        Name = str;
        VersionBios = str;
        TypeBios = str;
        SupporetedProcessorsList = new List<string>();
    }

    protected internal BiosSpecificator(
        string name,
        string coreFrequency,
        string typeBios,
        IEnumerable<string> supporetedProcessorsList)
    {
        Name = name;
        VersionBios = coreFrequency;
        TypeBios = typeBios;
        SupporetedProcessorsList = supporetedProcessorsList;
    }

    public string Name { get; set; }
    public string VersionBios { get; set; }
    public string TypeBios { get; set; }
    public IEnumerable<string> SupporetedProcessorsList { get; set; }
}