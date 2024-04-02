using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<CareMaterial> CareMaterials { get; set; } = new List<CareMaterial>();
}
