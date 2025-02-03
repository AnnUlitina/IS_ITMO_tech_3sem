using Itmo.ObjectOrientedProgramming.Lab1.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public interface IShip
{
    public bool HasAntinitrinoEmitter { get; }
    public IDeflector? Deflector { get; }
}