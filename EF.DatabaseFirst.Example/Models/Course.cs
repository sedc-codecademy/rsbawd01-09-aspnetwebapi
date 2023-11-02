using System;
using System.Collections.Generic;

namespace EF.DatabaseFirst.Example.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? TeacherId { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
