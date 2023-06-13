using ColorChecker.Domain;

namespace ColorChecker.Infrastructure.DataAccess
{
    public interface IPixelsRepository
    {
        Pixel Create(Pixel pixel);
    }
}