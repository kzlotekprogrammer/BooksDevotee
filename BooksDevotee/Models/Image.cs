using System;
using System.IO;

namespace BooksDevotee.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }


        public static string GetImageSource(Image image)
        {
            if (image == null)
            {
                return "/images/noimage.png";
            }
            else
            {
                string extension = Path.GetExtension(image.FileName);
                string base64Img = Convert.ToBase64String(image.ImageData);

                return $"data:image/{extension};base64,{base64Img}";
            }
        }
    }
}
