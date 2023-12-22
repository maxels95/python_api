using System;
using System.Collections.Generic;

namespace python_api.DTO;

public partial class ReadingDTO
{
    public double? Value { get; set; }

    public int SensorId { get; set; }

    public string? DateTime { get; set; }
}