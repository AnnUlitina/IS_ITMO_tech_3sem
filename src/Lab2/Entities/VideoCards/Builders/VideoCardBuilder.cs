using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public class VideoCardBuilder : VideoCardBuilderBase
{
    protected override IVideoCard Create(VideoCardSpecificator videoCardSpecificator)
    {
        return new VideoCard(videoCardSpecificator);
    }
}