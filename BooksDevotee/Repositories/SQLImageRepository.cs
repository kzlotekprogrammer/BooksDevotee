using BooksDevotee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace BooksDevotee.Repositories
{
    public class SQLImageRepository : IImageRepository
    {
        private readonly AppDbContext context;

        public SQLImageRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Image Add(Image image)
        {
            context.Images.Add(image);
            context.SaveChanges();
            return image;
        }

        public Image Delete(int id)
        {
            Image image = context.Images.Find(id);
            if (image != null)
            {
                context.Images.Remove(image);
                context.SaveChanges();
            }
            return image;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return context.Images;
        }

        public Image GetImage(int id)
        {
            return context.Images.Find(id);
        }

        public Image Update(Image imageChanges)
        {
            EntityEntry<Image> image = context.Images.Attach(imageChanges);
            image.State = EntityState.Modified;
            context.SaveChanges();
            return imageChanges;
        }
    }
}
