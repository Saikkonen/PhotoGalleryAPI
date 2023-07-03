using RestFulAPI.Models;

namespace RestFulAPI.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoGalleryContext _context;

        public PhotoRepository(PhotoGalleryContext context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return _context.Photos.ToList();
        }

        public Photo GetPhoto(int id)
        {
            return _context.Photos.Find(id);
        }

        public void AddPhoto(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void UpdatePhoto(Photo photo)
        {
            _context.Photos.Update(photo);
            _context.SaveChanges();
        }

        public void DeletePhoto(int id)
        {
            var photo = _context.Photos.Find(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                _context.SaveChanges();
            }
        }
    }
}
