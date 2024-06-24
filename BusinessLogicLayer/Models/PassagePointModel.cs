using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class PassagePointModel
    {
        public int PointId { get; set; }

        public string Title { get; set; } = null!;

        public int TypePointId { get; set; }

        public virtual ICollection<AccessPassagePointModel> AccessPassagePoints { get; set; } = new List<AccessPassagePointModel>();

        public virtual ICollection<PassagePointDepartmentModel> PassagePointDepartments { get; set; } = new List<PassagePointDepartmentModel>();

        public virtual ICollection<TimeZonePassagePointModel> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePointModel>();

        public virtual TypePointByAppointmentModel TypePoint { get; set; } = null!;
    }
}