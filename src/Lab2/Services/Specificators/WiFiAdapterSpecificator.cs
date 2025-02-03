namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class WiFiAdapterSpecificator
{
    protected internal WiFiAdapterSpecificator()
    {
        string str = string.Empty;
        WiFiStandardVersion = str;
        BuiltInBluetoothModule = str;
        VersionConnectionOptions = str;
        PowerConsumption = str;
    }

    protected internal WiFiAdapterSpecificator(
        string wiFiStandardVersion,
        string builtInBluetoothModule,
        string versionConnectionOptions,
        string powerConsumption)
    {
        WiFiStandardVersion = wiFiStandardVersion;
        BuiltInBluetoothModule = builtInBluetoothModule;
        VersionConnectionOptions = versionConnectionOptions;
        PowerConsumption = powerConsumption;
    }

    public string WiFiStandardVersion { get; set; }
    public string BuiltInBluetoothModule { get; set; }
    public string VersionConnectionOptions { get; set; }
    public string PowerConsumption { get; set; }
}