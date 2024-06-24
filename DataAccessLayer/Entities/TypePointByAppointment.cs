using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class TypePointByAppointment
{
    public int TypePointId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<PassagePoint> PassagePoints { get; set; } = new List<PassagePoint>();
}
