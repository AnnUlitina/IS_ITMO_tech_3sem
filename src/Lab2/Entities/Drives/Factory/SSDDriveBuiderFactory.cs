using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives.Factory;

public class SSDDriveBuiderFactory : IDriveBuilderFactory
{
    private SsdSpecificator _ssdDriveSpecificator;

    public SSDDriveBuiderFactory(SsdSpecificator ssdDriveSpecificator)
    {
        _ssdDriveSpecificator = ssdDriveSpecificator;
    }

    public IDrive Create()
    {
        return new SSDDrive(_ssdDriveSpecificator);
    }
}