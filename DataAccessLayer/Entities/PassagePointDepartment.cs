using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class PassagePointDepartment
{
    public int DepartmentId { get; set; }

    public int PointId { get; set; }

    public int Id { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual PassagePoint Point { get; set; } = null!;
}
