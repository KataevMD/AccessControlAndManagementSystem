using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class DaysTimeZone
{
    public int DaysTimeZoneId { get; set; }

    public int TimeIntervalId { get; set; }

    public int DayId { get; set; }

    public virtual Day Day { get; set; } = null!;

    public virtual TimeInterval TimeInterval { get; set; } = null!;
}
