using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static ForumApp2.Infrastructure.Constants.ValidationConstants;

namespace ForumApp2.Infrastructure.Data.Models
{
    [Comment("Post Table")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Post Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Post Content")]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
    }
}
