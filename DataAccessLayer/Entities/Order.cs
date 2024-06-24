using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int TypeOrderId { get; set; }

    public byte[] OrderFile { get; set; } = null!;

    public Guid EmployeeId { get; set; }

    public DateOnly StartDateAction { get; set; }

    public DateOnly? EndDateAction { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual TypeOrder TypeOrder { get; set; } = null!;
}
