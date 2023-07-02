namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Pictures;

    public interface IGalleryService
    {
        Task AddPictureAsync(PictureViewModel picture);

        Task RemovePicturesAsync(int id);

        Task<IEnumerable<PictureViewModel>> ShowPicturesAsync();
    }
}
