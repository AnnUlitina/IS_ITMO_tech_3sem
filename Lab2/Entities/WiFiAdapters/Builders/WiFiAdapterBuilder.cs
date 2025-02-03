using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters.Builders;

public class WiFiAdapterBuilder : WiFiAdapterBuilderBase
{
    protected override IWiFiAdapter Create(WiFiAdapterSpecificator wiFiAdapterSpecificator)
    {
        return new WiFiAdapter(wiFiAdapterSpecificator);
    }
}