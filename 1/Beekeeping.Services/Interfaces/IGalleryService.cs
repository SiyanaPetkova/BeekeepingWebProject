namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Pictures;

    public interface IGalleryService
    {
        void AddPictures(PictureViewModel picture);

        Task RemovePicturesAsync(int id);

        Task<ICollection<PictureViewModel>> ShowPicturesAsync();
    }
}
