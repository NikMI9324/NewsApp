using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NewsApp.Backend.News.Domain.Models
{
    public class News
    {
        public Guid NewsId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid UserId { get; private set; }
        public string UserName { get; private set; } = string.Empty;

        public News(string title, string content, Guid userId)
        {
            NewsId = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            UserId = userId;
        }


    }
}
