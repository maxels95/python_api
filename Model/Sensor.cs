using System;
using System.Collections.Generic;

namespace python_api.Model;

public partial class Sensor
{
    public int SensorId { get; set; }

    public int SensorType { get; set; }

    public int SensorPin { get; set; }

    public int SensorRelay { get; set; }

    public int ControlMode { get; set; }

    public int RelayManualState { get; set; }

    public virtual ICollection<Reading> Readings { get; } = new List<Reading>();
}
