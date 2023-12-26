using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace python_api.Model;

public partial class Reading
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReadingID { get; set; }

    public double? Value { get; set; }

    public int SensorID { get; set; }

    public string? DateTime { get; set; }
    [JsonIgnore]
    public virtual Sensor? Sensor { get; set; }
}
