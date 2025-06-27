using System;
using System.Collections.Generic;

namespace diary_blazor_web.Models;

public partial class Diary
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsPublic { get; set; }

    public byte? AllowComments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublicedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual User? User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
