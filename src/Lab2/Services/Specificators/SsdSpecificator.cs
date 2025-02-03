namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class SsdSpecificator
{
    protected internal SsdSpecificator()
    {
        string? str = string.Empty;
        Capacity = str;
        PowerConsumption = str;
        MaximumOperatingSpeed = str;
        ConnectionOptions = str;
    }

    protected internal SsdSpecificator(
        string capacity,
        string powerConsumption,
        string maximumOperatingSpeed,
        string connectionOptions)
    {
        PowerConsumption = powerConsumption;
        Capacity = capacity;
        ConnectionOptions = connectionOptions;
        MaximumOperatingSpeed = maximumOperatingSpeed;
    }

    public string Capacity { get; set; }
    public string PowerConsumption { get; set; }
    public string MaximumOperatingSpeed { get; set; }
    public string ConnectionOptions { get; set; }
}