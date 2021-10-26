using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDevotee.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
    }
}
