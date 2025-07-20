using System;
using System.Collections.Generic;

namespace diary_blazor_web.Models;

public partial class Tag
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Diary> Diaries { get; set; } = new List<Diary>();

    public string? UserId { get; set; }
    public virtual User? User { get; set; } = null!;
}
