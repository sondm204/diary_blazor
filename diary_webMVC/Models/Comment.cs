﻿using System;
using System.Collections.Generic;

namespace diary_webMVC.Models;

public partial class Comment
{
    public string Id { get; set; } = null!;

    public string? DiaryId { get; set; }

    public string? UserId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Diary? Diary { get; set; }

    public virtual User? User { get; set; }
}
