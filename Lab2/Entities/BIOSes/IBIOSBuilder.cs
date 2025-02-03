using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;

public interface IBiosBuilder
{
    IBiosBuilder WithVersion(string version);
    IBiosBuilder WithName(string name);
    IBiosBuilder WithType(string type);
    IBiosBuilder WithSupportedProcessorsList(IEnumerable<string> supportedProcessorsList);
    IBiosBuilder Direct(BiosSpecificator biosSpecificator);
    IBios Build();
}