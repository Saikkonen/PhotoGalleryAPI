using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFulAPI.Models
{
    [Table("AlbumPhoto")]
    public class AlbumPhoto
    {
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Album")]
        [Column("AlbumId")]
        public int AlbumId { get; set; }

        [ForeignKey("Photo")]
        [Column("PhotoId")]
        public int PhotoId { get; set; }
    }
}
