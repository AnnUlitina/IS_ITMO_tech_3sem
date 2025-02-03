using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class Validator : IValidator
{
    private ComputerBuilderBase _computerBuilderBase;

    public Validator(ComputerBuilderBase computerBuilderBase)
    {
        _computerBuilderBase = computerBuilderBase;
    }

    public BuildResult Run()
    {
        BiosValidator.Validator(_computerBuilderBase);
        HousingOfTheSystemUnitValidator.Validator(_computerBuilderBase);
        PowerUnitValidator.Validator(_computerBuilderBase);
        ProcessorValidator.Validator(_computerBuilderBase);
        ProcessorCoolingSystemValidator.Validator(_computerBuilderBase);
        RAMValidator.Validator(_computerBuilderBase);
        return _computerBuilderBase.BuildResult;
    }
}