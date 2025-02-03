using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes.Builders;

public abstract class BiosBuilderBase : IBiosBuilder
{
    private BiosSpecificator _biosSpecificator;
    protected BiosBuilderBase()
    {
        _biosSpecificator = new BiosSpecificator();
    }

    public IBiosBuilder WithVersion(string version)
    {
        _biosSpecificator.VersionBios = version;
        return this;
    }

    public IBiosBuilder WithName(string name)
    {
        _biosSpecificator.Name = name;
        return this;
    }

    public IBiosBuilder WithType(string type)
    {
        _biosSpecificator.TypeBios = type;
        return this;
    }

    public IBiosBuilder WithSupportedProcessorsList(IEnumerable<string> supportedProcessorsList)
    {
        _biosSpecificator.SupporetedProcessorsList = supportedProcessorsList;
        return this;
    }

    public IBiosBuilder Direct(BiosSpecificator biosSpecificator)
    {
        WithVersion(biosSpecificator.VersionBios);
        WithName(biosSpecificator.Name);
        WithType(biosSpecificator.TypeBios);
        WithSupportedProcessorsList(biosSpecificator.SupporetedProcessorsList);
        return this;
    }

    public IBios Build()
    {
        return Create(_biosSpecificator);
    }

    protected abstract IBios Create(BiosSpecificator biosSpecificator);
}