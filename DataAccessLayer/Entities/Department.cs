using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<AccessLevel> AccessLevels { get; set; } = new List<AccessLevel>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PassagePointDepartment> PassagePointDepartments { get; set; } = new List<PassagePointDepartment>();
}
