using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class TemperatureMethod
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<SeasonMethod> SeasonMethods { get; set; } = new List<SeasonMethod>();
}
