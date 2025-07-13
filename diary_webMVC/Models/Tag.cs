using System;
using System.Collections.Generic;

namespace diary_webMVC.Models;

public partial class Tag
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Diary> Diaries { get; set; } = new List<Diary>();
}
