using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NewsApp.Backend.News.Domain.Models
{
    internal class News
    {
        [Key]
        [Column("news_id")]
        public Guid NewsId { get; private set; }
        [Required]
        [MaxLength(200)]
        [Column("title", TypeName = "varchar(200)")]
        public string Title { get; private set; } = string.Empty;
        [Required]
        [Column("content", TypeName = "text")]
        public string Content { get; private set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        
        public Guid UserId { get; private set; }
        public string UserName { get; private set; } = string.Empty;

    }
}
