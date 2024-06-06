using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class PlannerTask
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsFixed { get; set; }

    public bool? IsDone { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
