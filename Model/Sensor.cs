using System;
using System.Collections.Generic;

namespace python_api.Model;

public partial class Sensor
{
    public long SensorId { get; set; }

    public long? SensorType { get; set; }

    public long? SensorPin { get; set; }

    public long? SensorRelay { get; set; }

    public long? ControlMode { get; set; }

    public long? RelayManualState { get; set; }

    public virtual ICollection<Reading> Readings { get; } = new List<Reading>();
}
