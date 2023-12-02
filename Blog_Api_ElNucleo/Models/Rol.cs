using System;
using System.Collections.Generic;

namespace Blog_Api_ElNucleo.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string? Rol1 { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
