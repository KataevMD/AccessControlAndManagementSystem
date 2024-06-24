using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class PassagePointDepartmentModel
    {
        public int DepartmentId { get; set; }

        public int PointId { get; set; }

        public int Id { get; set; }

        public virtual DepartmentModel Department { get; set; } = null!;

        public virtual PassagePointModel Point { get; set; } = null!;
    }
}