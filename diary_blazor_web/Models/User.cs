using System;
using System.Collections.Generic;

namespace diary_blazor_web.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Avatar { get; set; }

    public byte? IsPublic { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Diary> Diaries { get; set; } = new List<Diary>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
