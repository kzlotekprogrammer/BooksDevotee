using BooksDevotee.Models;
using System.Collections.Generic;

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
