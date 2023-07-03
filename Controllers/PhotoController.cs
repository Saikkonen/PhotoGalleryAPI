using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Data;
using RestFulAPI.Models;

namespace RestFulAPI.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpGet]
        public IActionResult GetAllPhotos()
        {
            var photos = _photoRepository.GetAllPhotos();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoto(int id)
        {
            var photo = _photoRepository.GetPhoto(id);
            if (photo == null)
            {
                return NotFound();
            }
            return Ok(photo);
        }

        [HttpPost]
        public IActionResult AddPhoto(Photo photo)
        {
            photo.UploadDate = DateTime.Now;

            _photoRepository.AddPhoto(photo);

            return CreatedAtAction(nameof(GetPhoto), new { id = photo.PhotoId }, photo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhoto(int id, Photo photo)
        {
            var existingPhoto = _photoRepository.GetPhoto(id);
            if (existingPhoto == null)
            {
                return NotFound();
            }

            existingPhoto.FilePath = photo.FilePath;
            existingPhoto.FileSize = photo.FileSize;
            existingPhoto.FileType = photo.FileType;

            _photoRepository.UpdatePhoto(existingPhoto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoto(int id)
        {
            var existingPhoto = _photoRepository.GetPhoto(id);
            if (existingPhoto == null)
            {
                return NotFound();
            }

            _photoRepository.DeletePhoto(id);

            return NoContent();
        }
    }
}
