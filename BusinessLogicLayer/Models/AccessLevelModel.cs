using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class AccessLevelModel
    {
        public int AccessLevelDepartmentId { get; set; }

        public string Title { get; set; } = null!;

        public int PostEmployeeId { get; set; }

        public int DepartmentId { get; set; }

        public virtual DepartmentModel Department { get; set; } = null!;

        public virtual PostModel PostEmployee { get; set; } = null!;

        public virtual ICollection<TimeZonePassagePointModel> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePointModel>();
    }
}