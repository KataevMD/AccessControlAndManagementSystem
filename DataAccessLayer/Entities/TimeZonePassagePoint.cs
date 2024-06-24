using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class TimeZonePassagePoint
{
    public int AccessLevelId { get; set; }

    public int PassagePointId { get; set; }

    public int TimeZoneId { get; set; }

    public virtual AccessLevel AccessLevel { get; set; } = null!;

    public virtual PassagePoint PassagePoint { get; set; } = null!;

    public virtual TimeZone TimeZone { get; set; } = null!;
}
