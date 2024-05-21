using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class UserTask
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TaskId { get; set; }

    public virtual PlannerTask? Task { get; set; }

    public virtual User? User { get; set; }
}
