using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Data;
using RestFulAPI.Models;

namespace RestFulAPI.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumRepository.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            var album = _albumRepository.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        public IActionResult AddAlbum(Album album)
        {
            album.CreationDate = DateTime.Now;

            _albumRepository.AddAlbum(album);

            return CreatedAtAction(nameof(GetAlbum), new { id = album.AlbumId }, album);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id, Album album)
        {
            var existingAlbum = _albumRepository.GetAlbum(id);
            if (existingAlbum == null)
            {
                return NotFound();
            }

            existingAlbum.Title = album.Title;

            _albumRepository.UpdateAlbum(existingAlbum);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var existingAlbum = _albumRepository.GetAlbum(id);
            if (existingAlbum == null)
            {
                return NotFound();
            }

            _albumRepository.DeleteAlbum(id);

            return NoContent();
        }
    }

}
