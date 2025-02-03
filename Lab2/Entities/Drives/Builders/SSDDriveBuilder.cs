using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives.Builders;

public class SSDDriveBuilder : IDriveBuilder
{
    private SsdSpecificator _ssdDriveSpecificator;

    protected SSDDriveBuilder(SsdSpecificator ssdDriveSpecificator)
    {
        _ssdDriveSpecificator = ssdDriveSpecificator;
    }

    public IDriveBuilder WithSpeed(string maximumOperatingSpeed)
    {
        _ssdDriveSpecificator.MaximumOperatingSpeed = maximumOperatingSpeed;
        return this;
    }

    public IDriveBuilder WithCapacity(string capacity)
    {
        _ssdDriveSpecificator.Capacity = capacity;
        return this;
    }

    public IDriveBuilder WithPower(string powerConsumption)
    {
        _ssdDriveSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IDriveBuilder WithConnection(string connectionOptions)
    {
        _ssdDriveSpecificator.ConnectionOptions = connectionOptions;
        return this;
    }

    public IDrive Build()
    {
        return Create(_ssdDriveSpecificator);
    }

    protected static IDrive Create(SsdSpecificator ssdDriveSpecificator)
    {
        return new SSDDrive(ssdDriveSpecificator);
    }
}