using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives.Factory;

public class HardDriveBuilderFactory : IDriveBuilderFactory
{
    private HardDriveSpecificator _hardDriveSpecificator;

    public HardDriveBuilderFactory(HardDriveSpecificator hardDriveSpecificator)
    {
        _hardDriveSpecificator = hardDriveSpecificator;
    }

    public IDrive Create()
    {
        return new HardDrive(_hardDriveSpecificator);
    }
}