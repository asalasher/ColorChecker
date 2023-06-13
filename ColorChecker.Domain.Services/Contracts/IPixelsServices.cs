using ColorChecker.Domain.Services;

namespace ColorChecker.Domain
{
    public interface IPixelsServices
    {
        PixelDTO RegisterNewColor(PixelDTO pxDTO);
    }
}