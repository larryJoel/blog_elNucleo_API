using System;
using System.Collections.Generic;

namespace Blog_Api_ElNucleo.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Brief { get; set; }

    public string? Contenido { get; set; }

    public string? Image { get; set; }

    public int? CategoryId { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual User? User { get; set; }
}
