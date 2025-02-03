using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public interface IWiFiAdapter
{
    public WiFiAdapterSpecificator WiFiAdapterSpecification { get; set; }
}