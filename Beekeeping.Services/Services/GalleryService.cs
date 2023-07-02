namespace Beekeeping.Services.Services
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Beekeeping.Data;
    using Beekeeping.Data.Models;
  
    using Beekeeping.Models.Pictures;
    using Beekeeping.Services.Interfaces;

    public class GalleryService : IGalleryService
    {
        private readonly BeekeepingDbContext dbcontext;

        public GalleryService(BeekeepingDbContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }

        public async Task AddPictureAsync(PictureViewModel model)
        {
            var picture = new Picture()
            {
                PictureName = model.PictureName,
                PicturePath = model.PicturePath
            };

            await dbcontext.Pictures.AddAsync(picture);
            await dbcontext.SaveChangesAsync();

        }

        public async Task RemovePicturesAsync(int id)
        {
            var currentPicture = await dbcontext.Pictures.FirstOrDefaultAsync(x => x.Id == id);

            if (currentPicture != null)
            {
                dbcontext.Pictures.Remove(currentPicture);

                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PictureViewModel>> ShowPicturesAsync()
        {
            var pictures = await dbcontext.Pictures.Select(g => new PictureViewModel
            {
                PicturePath = g.PicturePath,
                PictureName = g.PictureName
            })
           .AsNoTracking()
           .ToListAsync();

            return pictures;
        }
    }
}
