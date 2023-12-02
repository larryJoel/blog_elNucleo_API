using System;
using System.Collections.Generic;

namespace Blog_Api_ElNucleo.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Image { get; set; }

    public int? IdRol { get; set; }

    public string? Status { get; set; }

    public string? Kind { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
