namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public interface IPhotonicDeflector : IDeflector
{
    public DamageResult TakePhotonicDamage(double damage);
}