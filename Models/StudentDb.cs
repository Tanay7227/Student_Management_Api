using System;
using System.Collections.Generic;

namespace Practice_1.Models;

public partial class StudentDb
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }
}
