using AutoMapper;
using BLL.DTO;
using BLL.OtherClases;
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
        List<User> users = null;
        IMapper mapper = null;
        #region Wrappers
        Wrapper<City> wrapperCity = null;
        Wrapper<Tours> wrapperTours = null;
        Wrapper<Country> wrapperCountry = null;
        Wrapper<Hotels> wrapperHotels = null;
        Wrapper<ImagesHotels> wrapperImagesHotels = null;
        Wrapper<ImagesShowPlace> wrapperImagesShowPlace = null;
        Wrapper<ListClientShowInfoTour> wrapperListClientShowInfoTour = null;
        Wrapper<ListOfTouristBuy> wrapperListOfTouristBuy = null;
        Wrapper<Person> wrapperPerson = null;
        Wrapper<PointInTours> wrapperPointInTours = null;
        Wrapper<ResponsibleForTheTours> wrapperResponsibleForTheTours = null;
        Wrapper<ShowPlace> wrapperShowPlace = null;
        Wrapper<WaysOfTransportation> wrapperWaysOfTransportation = null;
        Wrapper<WaysInTours> wrapperWaysInTours = null;
        #endregion
        public AgensyService()
        {
            #region Wrappers
            wrapperCity = new Wrapper<City>();
            wrapperTours = new Wrapper<Tours>();
            wrapperCountry = new Wrapper<Country>();
            wrapperHotels = new Wrapper<Hotels>();
            wrapperImagesHotels = new Wrapper<ImagesHotels>();
            wrapperImagesShowPlace = new Wrapper<ImagesShowPlace>();
            wrapperListClientShowInfoTour = new Wrapper<ListClientShowInfoTour>();
            wrapperListOfTouristBuy = new Wrapper<ListOfTouristBuy>();
            wrapperPerson = new Wrapper<Person>();
            wrapperPointInTours = new Wrapper<PointInTours>();
            wrapperResponsibleForTheTours = new Wrapper<ResponsibleForTheTours>();
            wrapperShowPlace = new Wrapper<ShowPlace>();
            wrapperWaysOfTransportation = new Wrapper<WaysOfTransportation>();
            wrapperWaysInTours = new Wrapper<WaysInTours>();
            #endregion
            users = new List<User>();

            #region MapperConfiguration
            var config = new MapperConfiguration(x =>
                {
                    #region City
                    x.CreateMap<City, CityDTO>()
                                .ForMember("Country", opt => opt.MapFrom(c => mapper.Map<Country, CountryDTO>(c.Country)));
                    x.CreateMap<CityDTO, City>()
                    .ForMember("Country", opt => opt.MapFrom(c => mapper.Map<CountryDTO, Country>(c.Country)));
                    #endregion

                    #region Tours
                    x.CreateMap<Tours, ToursDTO>()
                    .ForMember("ListClientShowInfoTour", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListClientShowInfoTour>, IEnumerable<ListClientShowInfoTourDTO>>(c.ListClientShowInfoTour)))
                    .ForMember("ListOfTouristBuy", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListOfTouristBuy>, IEnumerable<ListOfTouristBuyDTO>>(c.ListOfTouristBuy)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInTours>, IEnumerable<PointInToursDTO>>(c.PointInTours)))
                    .ForMember("ResponsibleForTheTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ResponsibleForTheTours>, IEnumerable<ResponsibleForTheToursDTO>>(c.ResponsibleForTheTours)))
                    .ForMember("WaysInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInTours>, IEnumerable<WaysInToursDTO>>(c.WaysInTours)));
                    x.CreateMap<ToursDTO, Tours>()
                    .ForMember("ListClientShowInfoTour", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListClientShowInfoTourDTO>, IEnumerable<ListClientShowInfoTour>>(c.ListClientShowInfoTour)))
                    .ForMember("ListOfTouristBuy", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListOfTouristBuyDTO>, IEnumerable<ListOfTouristBuy>>(c.ListOfTouristBuy)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInToursDTO>, IEnumerable<PointInTours>>(c.PointInTours)))
                    .ForMember("ResponsibleForTheTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ResponsibleForTheToursDTO>, IEnumerable<ResponsibleForTheTours>>(c.ResponsibleForTheTours)))
                    .ForMember("WaysInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInToursDTO>, IEnumerable<WaysInTours>>(c.WaysInTours))); ;
                    #endregion

                    #region Country
                    x.CreateMap<Country, CountryDTO>()
                                .ForMember("City", opt => opt.Ignore());
                    x.CreateMap<CountryDTO, Country>()
                    .ForMember("City", opt => opt.Ignore());
                    #endregion

                    #region Hotels
                    x.CreateMap<Hotels, HotelsDTO>()
                    .ForMember("City", opt => opt.MapFrom(c => mapper.Map<City, CityDTO>(c.City)))
                    .ForMember("ImagesHotels", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesHotels>, IEnumerable<ImagesHotelsDTO>>(c.ImagesHotels)));
                    x.CreateMap<HotelsDTO, Hotels>()
                    .ForMember("City", opt => opt.MapFrom(c => mapper.Map<CityDTO, City>(c.City)))
                    .ForMember("ImagesHotels", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesHotelsDTO>, IEnumerable<ImagesHotels>>(c.ImagesHotels)));
                    #endregion

                    #region Person
                    x.CreateMap<Person, PersonDTO>()
                    .ForMember("ListClientShowInfoTour", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListClientShowInfoTour>, IEnumerable<ListClientShowInfoTourDTO>>(c.ListClientShowInfoTour)))
                    .ForMember("ListOfTouristBuy", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListOfTouristBuy>, IEnumerable<ListOfTouristBuyDTO>>(c.ListOfTouristBuy)))
                    .ForMember("ResponsibleForTheTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ResponsibleForTheTours>, IEnumerable<ResponsibleForTheToursDTO>>(c.ResponsibleForTheTours)));
                    x.CreateMap<PersonDTO, Person>()
                    .ForMember("ListClientShowInfoTour", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListClientShowInfoTourDTO>, IEnumerable<ListClientShowInfoTour>>(c.ListClientShowInfoTour)))
                    .ForMember("ListOfTouristBuy", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ListOfTouristBuyDTO>, IEnumerable<ListOfTouristBuy>>(c.ListOfTouristBuy)))
                    .ForMember("ResponsibleForTheTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ResponsibleForTheToursDTO>, IEnumerable<ResponsibleForTheTours>>(c.ResponsibleForTheTours)));
                    #endregion

                    #region ImagesHotels
                    x.CreateMap<ImagesHotels, ImagesHotelsDTO>()
                                .ForMember("Hotels", opt => opt.Ignore());
                    x.CreateMap<ImagesHotelsDTO, ImagesHotels>()
                    .ForMember("Hotels", opt => opt.Ignore());
                    #endregion

                    #region ImagesShowPlace
                    x.CreateMap<ShowPlace, ShowPlaceDTO>()
                    .ForMember("ImagesShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesShowPlace>, IEnumerable<ImagesShowPlaceDTO>>(c.ImagesShowPlace)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInTours>, IEnumerable<PointInToursDTO>>(c.PointInTours)));
                    x.CreateMap<ShowPlaceDTO, ShowPlace>()
                    .ForMember("ImagesShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesShowPlaceDTO>, IEnumerable<ImagesShowPlace>>(c.ImagesShowPlace)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInToursDTO>, IEnumerable<PointInTours>>(c.PointInTours)));
                    #endregion

                    #region ImagesShowPlace
                    x.CreateMap<ImagesShowPlace, ImagesShowPlaceDTO>()
                    .ForMember("ShowPlace", opt => opt.Ignore());
                    x.CreateMap<ImagesShowPlaceDTO, ImagesShowPlace>()
                    .ForMember("ShowPlace", opt => opt.Ignore());
                    #endregion

                    #region ListClientShowInfoTour
                    x.CreateMap<ListClientShowInfoTour, ListClientShowInfoTourDTO>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    x.CreateMap<ListClientShowInfoTourDTO, ListClientShowInfoTour>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    #endregion

                    #region ListOfTouristBuy
                    x.CreateMap<ListOfTouristBuy, ListOfTouristBuyDTO>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    x.CreateMap<ListOfTouristBuyDTO, ListOfTouristBuy>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    #endregion

                    #region PointInTours
                    x.CreateMap<PointInTours, PointInToursDTO>()
                    .ForMember("ShowPlace", opt => opt.Ignore())
                    .ForMember("Tours", opt => opt.Ignore());
                    x.CreateMap<PointInToursDTO, PointInTours>()
                    .ForMember("ShowPlace", opt => opt.Ignore())
                    .ForMember("Tours", opt => opt.Ignore());
                    #endregion

                    #region ResponsibleForTheTours
                    x.CreateMap<ResponsibleForTheTours, ResponsibleForTheToursDTO>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    x.CreateMap<ResponsibleForTheToursDTO, ResponsibleForTheTours>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("Person", opt => opt.Ignore());
                    #endregion

                    #region WaysOfTransportation
                    x.CreateMap<WaysOfTransportation, WaysOfTransportationDTO>();
                    x.CreateMap<WaysOfTransportationDTO, WaysOfTransportation>();
                    #endregion

                    #region WaysInTours
                    x.CreateMap<WaysInTours, WaysInToursDTO>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("City", opt => opt.Ignore())
                    .ForMember("City1", opt => opt.Ignore())
                    .ForMember("WaysOfTransportation", opt => opt.Ignore())
                    ;
                    x.CreateMap<WaysInToursDTO, WaysInTours>()
                    .ForMember("Tours", opt => opt.Ignore())
                    .ForMember("City", opt => opt.Ignore())
                    .ForMember("City1", opt => opt.Ignore())
                    .ForMember("WaysOfTransportation", opt => opt.Ignore());
                    #endregion
                });
            mapper = config.CreateMapper();
            #endregion
        }

        public void AddItem(CityDTO item)
        {
            wrapperCity.AddItem(mapper.Map<CityDTO, City>(item));
        }

        public void DeleteItem(CityDTO item)
        {
            wrapperCity.DeleteItem(mapper.Map<CityDTO, City>(item));
        }
       
        public void Disconect(PersonDTO person)
        {
            users.Remove(users.First(x=>x.Person == person));
        }

        public IEnumerable<CityDTO> GetAllCitys()
        {
            var temp = wrapperCity.GetItems();
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(temp);
        }

        public IEnumerable<ToursDTO> GetAllTours()
        {
            var temp = wrapperTours.GetItems();
            return mapper.Map<IEnumerable<Tours>, IEnumerable<ToursDTO>>(temp);
        }

        public List<CityDTO> GetTour(Tours tours)
        {
            throw new NotImplementedException();
        }

        public bool IsPersonOnline(PersonDTO person)
        {
            foreach (var item in users)
            {
                if (item.Person == person)
                    return true;
            }
            return false;
        }

        public bool IsUniqueLogin(string login)
        {
            var temp = wrapperPerson.GetItems();
            foreach (var item in temp)
            {
                if (item.Login == login)
                    return false;
            }
            return true;
        }

        public PersonDTO Login(string login, string password)
        {
            var tempUsers = mapper.Map<IEnumerable<Person>,IEnumerable<PersonDTO>>(wrapperPerson.GetItems());
            PersonDTO tempPerson = null;
            foreach (var item in tempUsers)
            {
                if (item.Login == login && item.Password == password)
                    tempPerson = item;
            }
            return tempPerson;
        }

        public void Registration(PersonDTO person)
        {
            wrapperPerson.AddItem(mapper.Map<PersonDTO, Person>(person));
            users.Add(new User()
            {
                Person = person,
                Callback = OperationContext.Current.GetCallbackChannel<ICallback>()
            });
        }
    }
}
