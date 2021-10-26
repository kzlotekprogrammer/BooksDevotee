using BooksDevotee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDevotee.Repositories
{
    public interface IImageRepository
    {
        Image GetImage(int id);
        IEnumerable<Image> GetAllImages();
        Image Add(Image image);
        Image Update(Image imageChanges);
        Image Delete(int id);
    }
}
