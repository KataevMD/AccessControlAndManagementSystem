using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class AccessLevel
{
    public int AccessLevelDepartmentId { get; set; }

    public string Title { get; set; } = null!;

    public int PostEmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Post PostEmployee { get; set; } = null!;

    public virtual ICollection<TimeZonePassagePoint> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePoint>();
}
