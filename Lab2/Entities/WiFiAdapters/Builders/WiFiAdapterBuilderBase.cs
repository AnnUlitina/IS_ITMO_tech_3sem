using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters.Builders;

public abstract class WiFiAdapterBuilderBase : IWiFiAdapterBuilder
{
    private WiFiAdapterSpecificator _wiFiAdapterSpecificator;

    protected WiFiAdapterBuilderBase()
    {
        _wiFiAdapterSpecificator = new WiFiAdapterSpecificator();
    }

    public IWiFiAdapterBuilder WithWiFiStandardVersion(string wiFiStandardVersion)
    {
        _wiFiAdapterSpecificator.WiFiStandardVersion = wiFiStandardVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithBuiltInBluetoothModule(string builtInBluetoothModule)
    {
        _wiFiAdapterSpecificator.BuiltInBluetoothModule = builtInBluetoothModule;
        return this;
    }

    public IWiFiAdapterBuilder WithVersionConnectionOptions(string versionConnectionOptions)
    {
        _wiFiAdapterSpecificator.VersionConnectionOptions = versionConnectionOptions;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(string powerConsumption)
    {
        _wiFiAdapterSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IWiFiAdapterBuilder Direct(WiFiAdapterSpecificator wiFiAdapterSpecificator)
    {
        WithWiFiStandardVersion(wiFiAdapterSpecificator.WiFiStandardVersion);
        WithBuiltInBluetoothModule(wiFiAdapterSpecificator.BuiltInBluetoothModule);
        WithVersionConnectionOptions(wiFiAdapterSpecificator.VersionConnectionOptions);
        WithPowerConsumption(wiFiAdapterSpecificator.PowerConsumption);
        return this;
    }

    public IWiFiAdapter Build()
    {
        return Create(_wiFiAdapterSpecificator);
    }

    protected abstract IWiFiAdapter Create(WiFiAdapterSpecificator wiFiAdapterSpecificator);
}