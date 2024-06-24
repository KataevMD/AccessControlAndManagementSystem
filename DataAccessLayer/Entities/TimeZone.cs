using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class TimeZone
{
    public int TimeZoneId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<TimeInterval> TimeIntervals { get; set; } = new List<TimeInterval>();

    public virtual ICollection<TimeZonePassagePoint> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePoint>();
}
