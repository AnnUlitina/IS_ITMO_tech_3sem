using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives.Builders;

public class HardDriveBuilder : IDriveBuilder
{
    private HardDriveSpecificator _hardDriveSpecificator;

    public HardDriveBuilder(HardDriveSpecificator hardDriveSpecificator)
    {
        _hardDriveSpecificator = hardDriveSpecificator;
    }

    public IDriveBuilder WithRotationSpeed(string spindleRotationSpeed)
    {
        _hardDriveSpecificator.SpindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IDriveBuilder WithCapacity(string capacity)
    {
        _hardDriveSpecificator.Capacity = capacity;
        return this;
    }

    public IDriveBuilder WithPower(string powerConsumption)
    {
        _hardDriveSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IDriveBuilder Direct(HardDriveSpecificator hardDriveSpecificator)
    {
        WithRotationSpeed(hardDriveSpecificator.SpindleRotationSpeed);
        WithCapacity(hardDriveSpecificator.Capacity);
        WithPower(hardDriveSpecificator.PowerConsumption);
        return this;
    }

    public IDrive Build()
    {
        return Create(_hardDriveSpecificator);
    }

    protected static IDrive Create(HardDriveSpecificator hardDriveSpecificator)
    {
        return new HardDrive(hardDriveSpecificator);
    }
}