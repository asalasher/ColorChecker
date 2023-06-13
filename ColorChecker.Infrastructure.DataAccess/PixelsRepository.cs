using ColorChecker.Domain;
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
            pixels.Add(JsonConvert.SerializeObject(pixel));
            File.WriteAllLines(_storageFilePath, pixels);

            return pixel;
        }

    }
}
