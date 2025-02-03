namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class SupportedJEDECAnsVoltageFrequencyPairs
{
    public SupportedJEDECAnsVoltageFrequencyPairs(double volrage, double jedecFrequencies)
    {
        Volrage = volrage;
        JedecFrequencies = jedecFrequencies;
    }

    public double Volrage { get; }
    public double JedecFrequencies { get; }
}