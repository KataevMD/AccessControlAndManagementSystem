using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class PassagePoint
{
    public int PointId { get; set; }

    public string Title { get; set; } = null!;

    public int TypePointId { get; set; }

    public virtual ICollection<AccessPassagePoint> AccessPassagePoints { get; set; } = new List<AccessPassagePoint>();

    public virtual ICollection<PassagePointDepartment> PassagePointDepartments { get; set; } = new List<PassagePointDepartment>();

    public virtual ICollection<TimeZonePassagePoint> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePoint>();

    public virtual TypePointByAppointment TypePoint { get; set; } = null!;
}
