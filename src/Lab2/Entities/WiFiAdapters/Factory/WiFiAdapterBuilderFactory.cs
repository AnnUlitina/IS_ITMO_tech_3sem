using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters.Factory;

public class WiFiAdapterBuilderFactory : IWiFiAdapterBuilderFactory
{
    public IWiFiAdapterBuilder Create()
    {
        return new WiFiAdapterBuilder();
    }
}