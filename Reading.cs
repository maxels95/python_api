namespace python_api;

public class Reading
{
    public int ReadingID { get; set; }

    public int SensorID { get; set; }

    public int ReadingType { get; set; }

    public DateTime TimeStamp { get; set; }
    public int RelayControl { get; set; }
    public int ControlMode { get; set; }
}
