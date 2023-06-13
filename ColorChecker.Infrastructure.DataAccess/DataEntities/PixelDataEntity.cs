using System;

namespace ColorChecker.Infrastructure.DataAccess.DataEntities
{
    public class PixelDataEntity
    {
        public string Color { get; set; }
        public int Intensity { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
