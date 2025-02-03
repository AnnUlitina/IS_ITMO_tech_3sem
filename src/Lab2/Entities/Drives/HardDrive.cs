using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;

public class HardDrive : IDrive
{
    public HardDrive(
        HardDriveSpecificator hardDriveSpecificator)
    {
        HardDriveSpecification = hardDriveSpecificator;
    }

    public HardDriveSpecificator HardDriveSpecification { get; }
}