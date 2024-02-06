using AutoMapper;
using WebApp.Domain.Models;

namespace WebApp.MVC.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BikeStation,BikeStationDTO> ();
        }
    }
}
