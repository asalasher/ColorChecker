using ColorChecker.Domain.CustomExceptions;
using ColorChecker.Domain.Services;
using ColorChecker.Infrastructure.DataAccess;
using System;

namespace ColorChecker.Domain
{
    public class PixelsServices : IPixelsServices
    {
        private readonly IPixelsRepository _pixelsRepository;

        public PixelsServices(IPixelsRepository pxRepository)
        {
            _pixelsRepository = pxRepository;
        }

        public PixelDTO RegisterNewColor(PixelDTO pxDTO)
        {

            try
            {
                Pixel pixel = pxDTO.MappingToDomainEntity();
                pixel.Validate();

                var insertedPixel = _pixelsRepository.Create(pixel);
                return pxDTO;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

    }
}
