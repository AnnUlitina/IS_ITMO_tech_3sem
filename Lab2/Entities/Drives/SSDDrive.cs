using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;

public class SSDDrive : IDrive
{
    public SSDDrive(SsdSpecificator ssdDriveSpecificator)
    {
        SSDDriveSpecification = ssdDriveSpecificator;
    }

    public SsdSpecificator SSDDriveSpecification { get; set; }
}