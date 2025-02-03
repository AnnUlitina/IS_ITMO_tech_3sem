using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public class VideoCard : IVideoCard
{
    public VideoCard(VideoCardSpecificator videoCardSpecificator)
    {
        VideoCardSpecification = videoCardSpecificator;
    }

    public VideoCardSpecificator VideoCardSpecification { get; }
}