using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<AccessLevel> AccessLevels { get; set; } = new List<AccessLevel>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
