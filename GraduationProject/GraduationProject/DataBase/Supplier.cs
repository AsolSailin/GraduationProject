using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<MaterialSupplier> MaterialSuppliers { get; set; } = new List<MaterialSupplier>();
}
