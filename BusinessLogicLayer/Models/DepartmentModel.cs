using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<AccessLevelModel> AccessLevels { get; set; } = new List<AccessLevelModel>();

        public virtual ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        public virtual ICollection<PassagePointDepartmentModel> PassagePointDepartments { get; set; } = new List<PassagePointDepartmentModel>();
    }
}