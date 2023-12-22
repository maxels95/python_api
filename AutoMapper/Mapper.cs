
using AutoMapper;
using python_api.DTO;
using python_api.Model;

public class PythonMappingProfile : Profile
{
    public PythonMappingProfile()
    {
        CreateMap<Reading, ReadingDTO>();
        CreateMap<ReadingDTO, Reading>();
        CreateMap<IEnumerable<Reading>, IEnumerable<ReadingDTO>>();
        CreateMap<IEnumerable<ReadingDTO>, IEnumerable<Reading>>();
        
        CreateMap<Sensor, SensorDTO>();
        CreateMap<SensorDTO, Sensor>();
        CreateMap<IEnumerable<Sensor>, IEnumerable<SensorDTO>>();
        CreateMap<IEnumerable<SensorDTO>, IEnumerable<Sensor>>();
    }
}