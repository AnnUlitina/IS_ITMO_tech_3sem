using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes.Factory;

public class BIOSBuilderFactory : IBiosBuilderFactory
{
    public IBiosBuilder Create()
    {
        return new BiosBuilder();
    }
}