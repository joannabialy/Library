using System.IO;

namespace Library.Application.Utils
{
    public static class ImageHelper
    {
        public static byte[] ReadImage(string path)
        {
            byte[] data;

            var fileInfo = new FileInfo(path);
            long numBytes = fileInfo.Length;

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (var binaryReader = new BinaryReader(fileStream))
            {
                data = binaryReader.ReadBytes((int)numBytes);
            }

            return data;
        }
    }
}
