﻿using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class AnimalReport
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? ReportId { get; set; }

    public string? Condition { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Report? Report { get; set; }
}
