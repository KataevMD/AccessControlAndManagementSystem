using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class Day
{
    public int DayId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<DaysTimeZone> DaysTimeZones { get; set; } = new List<DaysTimeZone>();
}
