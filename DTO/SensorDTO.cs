using System;
using System.Collections.Generic;

namespace python_api.DTO;

public partial class SensorDTO
{
    public int SensorType { get; set; }

    public int SensorPin { get; set; }

    public int SensorRelay { get; set; }

    public int ControlMode { get; set; }

    public int RelayManualState { get; set; }
}
