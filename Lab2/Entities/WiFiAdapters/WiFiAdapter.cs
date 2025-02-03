using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public class WiFiAdapter : IWiFiAdapter
{
    public WiFiAdapter(WiFiAdapterSpecificator specificator)
    {
        WiFiAdapterSpecification = specificator;
    }

    public WiFiAdapterSpecificator WiFiAdapterSpecification { get; set; }
}