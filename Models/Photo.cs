using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFulAPI.Models
{
    [Table("Photo")]
    public class Photo
    {
        [Key]
        [Column("PhotoId")]
        public int PhotoId { get; set; }

        [Column("FilePath")]
        public string? FilePath { get; set; }

        [Column("UploadDate")]
        public DateTime UploadDate { get; set; }

        [Column("FileSize")]
        public long FileSize { get; set; }

        [Column("FileType")]
        public string? FileType { get; set; }
    }
}
