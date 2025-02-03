using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Factory;

public class VideoCardBuilderFactory : IVideoCardBuilderFactory
{
    public IVideoCardBuilder Create()
    {
        return new VideoCardBuilder();
    }
}