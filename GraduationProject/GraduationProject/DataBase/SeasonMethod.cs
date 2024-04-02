using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class SeasonMethod
{
    public int Id { get; set; }

    public int SeasonId { get; set; }

    public int MethodId { get; set; }

    public virtual TemperatureMethod Method { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;
}
