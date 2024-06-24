using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class EmployeeModel
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

        public string FullName { get { return FirstName + " " + LastName + " " + Patronymic; } }
    }
}
