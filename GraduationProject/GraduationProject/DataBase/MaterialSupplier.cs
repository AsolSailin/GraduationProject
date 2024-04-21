using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class MaterialSupplier
{
    public int Id { get; set; }

    public int? MaterialId { get; set; }

    public int? SupplierId { get; set; }

    public int? Count { get; set; }

    public int? PeriodInDay { get; set; }

    public decimal? Price { get; set; }

    public virtual CareMaterial? Material { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
