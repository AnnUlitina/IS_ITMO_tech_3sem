namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record FormFactorRam
{
    public record Dimm : FormFactorRam;
    public record SoDimm : FormFactorRam;
}