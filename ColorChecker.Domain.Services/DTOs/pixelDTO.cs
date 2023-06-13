using System.ComponentModel.DataAnnotations;

namespace ColorChecker.Domain.Services
{
    [MetadataType(typeof(PixelDTO))]
    public class PixelDTO
    {
        public ColorNames Color { get; set; }
        public int Intensity { get; set; }
        public string Name { get; set; }

    }
}
