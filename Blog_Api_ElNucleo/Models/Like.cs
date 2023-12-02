using System;
using System.Collections.Generic;

namespace Blog_Api_ElNucleo.Models;

public partial class Like
{
    public int Id { get; set; }

    public int? IdPost { get; set; }

    public int? PositiveLike { get; set; }

    public int? NegativeLike { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Post? IdPostNavigation { get; set; }
}
