using RestFulAPI.Models;

namespace RestFulAPI.Data
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly PhotoGalleryContext _context;

        public AlbumRepository(PhotoGalleryContext context)
        {
            _context = context;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            var albums = _context.Albums.ToList();
            foreach (var album in albums)
            {
                var id = album.AlbumId;
                var albumList = _context.AlbumPhotos.Where(a => a.AlbumId == id).ToList();

            }
            return albums;
        }

        public Album GetAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.AlbumId == id);
            var albumList = _context.AlbumPhotos.Where(a => a.AlbumId == id).ToList();
            return album;
        }

        public void AddAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void UpdateAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _context.Albums.Update(album);
            _context.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.AlbumId == id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }
    }
}
