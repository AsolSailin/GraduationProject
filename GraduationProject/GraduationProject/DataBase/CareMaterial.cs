using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class CareMaterial
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int TypeId { get; set; }

    public string? Description { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? MeasurementUnitId { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<AnimalMaterial> AnimalMaterials { get; set; } = new List<AnimalMaterial>();

    public virtual MeasurementUnit? MeasurementUnit { get; set; }

    public virtual MaterialType Type { get; set; } = null!;
}
