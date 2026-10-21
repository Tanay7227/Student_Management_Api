using System;
using System.Collections.Generic;

namespace Practice_1.Models;

public partial class StudentTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Course { get; set; } = null!;
}
