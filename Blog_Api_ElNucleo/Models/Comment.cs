using System;
using System.Collections.Generic;

namespace Blog_Api_ElNucleo.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Comment1 { get; set; }

    public int? PostId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public string? Clave { get; set; }

    public int? IdRol { get; set; }

    public virtual Post? Post { get; set; }
}
