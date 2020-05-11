using AutoMapper;
using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BLL
{
    public class AgensyService : IAgensyService
    {
        Wrapper<City> wrapper = null;
        Wrapper<Tours> wrapperTours = null;
        IMapper mapperCity = null;
        IMapper mapperTours = null;
        IMapper mapperCountry = null;
        public AgensyService()
        {
            wrapper = new Wrapper<City>();
            wrapperTours = new Wrapper<Tours>();
            City city = new City();

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<City, CityDTO>()
                .ForMember("Country", opt => opt.MapFrom(c => mapperCountry.Map<Country,CountryDTO>(c.Country)));
                x.CreateMap<CityDTO, City>();
            });
            mapperCity = config.CreateMapper();
            var config1 = new MapperConfiguration(x =>
            {
                x.CreateMap<Country, CountryDTO>().ForMember("City", opt => opt.Ignore());
                //.ForMember("City", opt => opt.MapFrom(c => mapperCountry.Map<IEnumerable<City>, IEnumerable<CityDTO>>(c.City)));
                x.CreateMap<CountryDTO, Country>();
            });
            mapperCountry = config1.CreateMapper();
            config = new MapperConfiguration(x =>
            {
                x.CreateMap<Tours, ToursDTO>();
                x.CreateMap<ToursDTO, Tours>();
            });
            mapperTours = config.CreateMapper();
        }

        public void AddItem(City item)
        {
            wrapper.AddItem(item);
        }

        public void DeleteItem(City item)
        {
            wrapper.DeleteItem(item);
        }

        public void Disconect(Person user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetAllCitys()
        {
            var temp = wrapper.GetItems();
            return mapperCity.Map<IEnumerable<City>, IEnumerable<CityDTO>>(temp);
        }

        public IEnumerable<ToursDTO> GetAllTours()
        {
            return mapperTours.Map<IEnumerable<Tours>,IEnumerable<ToursDTO>>(wrapperTours.GetItems());
        }

        public List<CityDTO> GetTour(Tours tours)
        {
            throw new NotImplementedException();
        }

        public Person Login()
        {
            throw new NotImplementedException();
        }
    }
}
