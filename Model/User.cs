using System;
using System.Collections.Generic;

namespace python_api.Model;

public partial class User
{
    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }
}
