using ColorChecker.Domain.Services.CustomExceptions;
using System.Collections.Generic;

namespace ColorChecker.Domain
{
    public class Pixel
    {
        public string Color { get; set; }
        public int Intensity { get; set; }
        public string Name { get; set; }

        public bool Validate()
        {
            var validColors = new List<string> { "Red", "Green", "Blue" };

            if (!validColors.Contains(Color))
            {
                throw new ParsingReqPayloadException("Colors must me Red, Green or Blue");
            }

            if (Intensity < 0 || Intensity > 100)
            {
                throw new ParsingReqPayloadException("Intensity must be between 0 and 100");
            }

            return true;
        }
    }
}
