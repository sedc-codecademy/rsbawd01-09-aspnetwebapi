using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.DatabaseFirst.DAL.Models;

public partial class Course
{
    public int CourseId { get; set; }

    // Data annotations for SQL Server inside of our classes using C# Attributes
    //[Required]
    //[MaxLength(100)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    //[ForeignKey("TeacherId")]
    public int? TeacherId { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
