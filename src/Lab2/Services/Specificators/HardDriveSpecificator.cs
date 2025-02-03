namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class HardDriveSpecificator
{
    protected internal HardDriveSpecificator()
    {
        string str = string.Empty;
        PowerConsumption = str;
        SpindleRotationSpeed = str;
        Capacity = str;
    }

    protected internal HardDriveSpecificator(
        string capacity,
        string powerConsumption,
        string spindleRotationSpeed)
    {
        PowerConsumption = powerConsumption;
        SpindleRotationSpeed = spindleRotationSpeed;
        Capacity = capacity;
    }

    public string Capacity { get; set; }
    public string PowerConsumption { get; set; }
    public string SpindleRotationSpeed { get; set; }
}