using ColorChecker.Domain;
using ColorChecker.Infrastructure.DataAccess.DataEntities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace ColorChecker.Infrastructure.DataAccess
{
    public class PixelsRepository : IPixelsRepository
    {
        private readonly string _storageFileName = "pixelsStore.json";
        private readonly string _storageFilePath;

        public PixelsRepository()
        {
            _storageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalStore", _storageFileName);
        }

        public Pixel Create(Pixel pixel)
        {
            var pixels = File.ReadLines(_storageFilePath).ToList();
            var newPixelRecord = new PixelDataEntity
            {
                Name = pixel.Name,
                Color = pixel.Color,
                Intensity = pixel.Intensity,
                Date = DateTime.Now
            };
            pixels.Add(JsonConvert.SerializeObject(newPixelRecord));
            File.WriteAllLines(_storageFilePath, pixels);

            return pixel;
        }

    }
}
