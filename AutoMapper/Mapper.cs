
using AutoMapper;
using python_api.DTO;
using python_api.Model;

public class PythonMappingProfile : Profile
{
    public PythonMappingProfile()
    {
        CreateMap<Reading, ReadingDTO>();
        CreateMap<ReadingDTO, Reading>();

        CreateMap<Sensor, SensorDTO>();
        CreateMap<SensorDTO, Sensor>();
    }
}