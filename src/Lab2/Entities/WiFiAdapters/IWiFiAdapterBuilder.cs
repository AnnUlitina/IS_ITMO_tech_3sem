using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public interface IWiFiAdapterBuilder
{
    public IWiFiAdapterBuilder WithWiFiStandardVersion(string wiFiStandardVersion);

    public IWiFiAdapterBuilder WithBuiltInBluetoothModule(string builtInBluetoothModule);

    public IWiFiAdapterBuilder WithVersionConnectionOptions(string versionConnectionOptions);

    public IWiFiAdapterBuilder WithPowerConsumption(string powerConsumption);
    IWiFiAdapterBuilder Direct(WiFiAdapterSpecificator wiFiAdapterSpecificator);

    IWiFiAdapter Build();
}