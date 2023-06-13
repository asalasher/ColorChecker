using ColorChecker.Domain.Services.CustomExceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColorChecker.Domain.Services
{
    [MetadataType(typeof(PixelDTO))]
    public class PixelDTO
    {
        public string Color { get; set; }
        public int Intensity { get; set; }
        public string Name { get; set; }
    }

    public static class ExtensionsPixelDTO
    {
        public static Pixel MappingToDomainEntity(this PixelDTO pxDTO)
        {
            return new Pixel
            {
                Color = pxDTO.Color,
                Intensity = pxDTO.Intensity,
                Name = pxDTO.Name
            };
        }

        public static PixelDTO MappingPayloadToDTO(this PixelDTO pxDTO, List<string> payload)
        {
            if (payload.Count != 3)
            {
                throw new ParsingReqPayloadException("The number of values must be 3");
            }

            if (string.IsNullOrEmpty(payload[0]))
            {
                throw new ParsingReqPayloadException("The color name can not be null or empty");
            }
            else
            {
                pxDTO.Color = payload[0];
            }

            if (int.TryParse(payload[1], out int intensity))
            {
                pxDTO.Intensity = intensity;
            }
            else
            {
                throw new ParsingReqPayloadException("the intensity value must be an integer");
            }

            pxDTO.Name = payload[2];

            return pxDTO;
        }

    }

}

