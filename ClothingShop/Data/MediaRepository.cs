using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Data
{
    public class MediaRepository: IMediaRepository
    {
        private readonly ApplicationDbContext context;

        public MediaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Media> GetMedias()
        {
            return context.Medias.ToList();
        }
       

    }
}
