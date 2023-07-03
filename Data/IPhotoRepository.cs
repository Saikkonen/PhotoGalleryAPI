using RestFulAPI.Models;

namespace RestFulAPI.Data
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAllPhotos();
        Photo GetPhoto(int id);
        void AddPhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        void DeletePhoto(int id);
    }
}
