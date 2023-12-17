using System;
using System.Collections.Generic;

namespace python_api.Model;

public partial class Reading
{
    public int ReadingId { get; set; }

    public double? Value { get; set; }

    public int SensorId { get; set; }

    public string? DateTime { get; set; }

    public virtual Sensor Sensor { get; set; }
}
