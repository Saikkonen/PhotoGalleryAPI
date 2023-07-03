using RestFulAPI.Models;

namespace RestFulAPI.Data
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int id);
        void AddAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(int id);
    }
}
