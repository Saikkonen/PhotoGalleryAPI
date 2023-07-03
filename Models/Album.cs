using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFulAPI.Models
{
    [Table("Album")]
    public class Album
    {
        [Key]
        [Column("AlbumId")]
        public int AlbumId { get; set; }

        [Column("Title")]
        public string? Title { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        public List<AlbumPhoto>? AlbumPhotos { get; set; }
    }
}
