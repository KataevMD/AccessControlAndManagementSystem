using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class TimeInterval
{
    public int TimeIntervalId { get; set; }

    public string Title { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int TimeZoneId { get; set; }

    public virtual ICollection<DaysTimeZone> DaysTimeZones { get; set; } = new List<DaysTimeZone>();

    public virtual TimeZone TimeZone { get; set; } = null!;
}
