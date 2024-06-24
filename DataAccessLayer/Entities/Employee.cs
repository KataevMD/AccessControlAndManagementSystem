using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class Employee
{
    public Guid EmployeeGuid { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly DateBirthday { get; set; }
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int PostId { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<AccessPassagePoint> AccessPassagePoints { get; set; } = new List<AccessPassagePoint>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Post Post { get; set; } = null!;
}
