using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IComputerBuilderDirector
{
    IComputerBuilder Direct(IComputerBuilder builder, Specificator specificator);
}