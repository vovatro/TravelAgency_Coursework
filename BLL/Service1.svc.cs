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
                    .ForMember("Country", opt => opt.MapFrom(c => mapper.Map<Country, CountryDTO>(c.Country)))
                    .ForMember("ShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ShowPlace>, IEnumerable<ShowPlaceDTO>>(c.ShowPlace)))
                    .ForMember("Hotels", opt => opt.MapFrom(c => mapper.Map<IEnumerable<Hotels>, IEnumerable<HotelsDTO>>(c.Hotels)))
                    .ForMember("WaysInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInTours>, IEnumerable<WaysInToursDTO>>(c.WaysInTours)))
                    .ForMember("WaysInTours1", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInTours>, IEnumerable<WaysInToursDTO>>(c.WaysInTours1)))
                    ;
                    x.CreateMap<CityDTO, City>()
                    .ForMember("Country", opt => opt.MapFrom(c => mapper.Map<CountryDTO, Country>(c.Country)))
                    .ForMember("ShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ShowPlaceDTO>, IEnumerable<ShowPlace>>(c.ShowPlace)))
                    .ForMember("Hotels", opt => opt.MapFrom(c => mapper.Map<IEnumerable<HotelsDTO>, IEnumerable<Hotels>>(c.Hotels)))
                    .ForMember("WaysInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInToursDTO>, IEnumerable<WaysInTours>>(c.WaysInTours)))
                    .ForMember("WaysInTours1", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInToursDTO>, IEnumerable<WaysInTours>>(c.WaysInTours1)))
                    ;
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
                    .ForMember("WaysInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<WaysInToursDTO>, IEnumerable<WaysInTours>>(c.WaysInTours))); 
                    #endregion

                    #region Country
                    x.CreateMap<Country, CountryDTO>()
                                .ForMember("City", opt => opt.Ignore());
                    x.CreateMap<CountryDTO, Country>()
                    .ForMember("City", opt => opt.Ignore());
                    #endregion

                    #region Hotels
                    x.CreateMap<Hotels, HotelsDTO>()
                    .ForMember("City", opt => opt.Ignore())
                    .ForMember("ImagesHotels", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesHotels>, IEnumerable<ImagesHotelsDTO>>(c.ImagesHotels)));
                    x.CreateMap<HotelsDTO, Hotels>()
                    .ForMember("City", opt => opt.Ignore())
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
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInTours>, IEnumerable<PointInToursDTO>>(c.PointInTours)))
                    .ForMember("City", opt => opt.Ignore())
                    ;
                    x.CreateMap<ShowPlaceDTO, ShowPlace>()
                    .ForMember("ImagesShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesShowPlaceDTO>, IEnumerable<ImagesShowPlace>>(c.ImagesShowPlace)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInToursDTO>, IEnumerable<PointInTours>>(c.PointInTours)))
                    .ForMember("City", opt => opt.Ignore())
                    ;
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

                    #region ShowPlace
                    x.CreateMap<ShowPlace, ShowPlaceDTO>()
                    .ForMember("City", opt => opt.Ignore())
                    .ForMember("ImagesShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesShowPlace>, IEnumerable<ImagesShowPlaceDTO>>(c.ImagesShowPlace)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInTours>, IEnumerable<PointInToursDTO>>(c.PointInTours)))
                    ;
                    x.CreateMap<ShowPlaceDTO, ShowPlace>()
                    .ForMember("City", opt => opt.Ignore())
                    .ForMember("ImagesShowPlace", opt => opt.MapFrom(c => mapper.Map<IEnumerable<ImagesShowPlaceDTO>, IEnumerable<ImagesShowPlace>>(c.ImagesShowPlace)))
                    .ForMember("PointInTours", opt => opt.MapFrom(c => mapper.Map<IEnumerable<PointInToursDTO>, IEnumerable<PointInTours>>(c.PointInTours)))
                    ;
                    #endregion
                });
            mapper = config.CreateMapper();
            #endregion
        }

        #region AddItem
        public void AddItem(CityDTO item)
        {
            wrapperCity.AddItem(mapper.Map<CityDTO, City>(item));
        }

        public void AddItem(CountryDTO item)
        {
            wrapperCountry.AddItem(mapper.Map<CountryDTO, Country>(item));
        }

        public void AddItem(HotelsDTO item)
        {
            wrapperHotels.AddItem(mapper.Map<HotelsDTO, Hotels>(item));
        }

        public void AddItem(ImagesHotelsDTO item)
        {
            wrapperImagesHotels.AddItem(mapper.Map<ImagesHotelsDTO, ImagesHotels>(item));
        }

        public void AddItem(ImagesShowPlaceDTO item)
        {
            wrapperImagesShowPlace.AddItem(mapper.Map<ImagesShowPlaceDTO, ImagesShowPlace>(item));
        }

        public void AddItem(ListClientShowInfoTourDTO item)
        {
            wrapperListClientShowInfoTour.AddItem(mapper.Map<ListClientShowInfoTourDTO, ListClientShowInfoTour>(item));
        }

        public void AddItem(ListOfTouristBuyDTO item)
        {
            wrapperListOfTouristBuy.AddItem(mapper.Map<ListOfTouristBuyDTO, ListOfTouristBuy>(item));
        }

        public void AddItem(PersonDTO item)
        {
            wrapperPerson.AddItem(mapper.Map<PersonDTO, Person>(item));
        }

        public void AddItem(PointInToursDTO item)
        {
            wrapperPointInTours.AddItem(mapper.Map<PointInToursDTO, PointInTours>(item));
        }

        public void AddItem(ResponsibleForTheToursDTO item)
        {
            wrapperResponsibleForTheTours.AddItem(mapper.Map<ResponsibleForTheToursDTO, ResponsibleForTheTours>(item));
        }

        public void AddItem(ShowPlaceDTO item)
        {
            wrapperShowPlace.AddItem(mapper.Map<ShowPlaceDTO, ShowPlace>(item));
        }

        public void AddItem(ToursDTO item)
        {
            wrapperTours.AddItem(mapper.Map<ToursDTO, Tours>(item));
        }

        public void AddItem(WaysInToursDTO item)
        {
            wrapperWaysInTours.AddItem(mapper.Map<WaysInToursDTO, WaysInTours>(item));
        }

        public void AddItem(WaysOfTransportationDTO item)
        {
            wrapperWaysOfTransportation.AddItem(mapper.Map<WaysOfTransportationDTO, WaysOfTransportation>(item));
        }
        #endregion

        #region GetAll
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

        public IEnumerable<CountryDTO> GetAllCountry()
        {
            var temp = wrapperCountry.GetItems();
            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(temp);
        }

        public IEnumerable<HotelsDTO> GetAllHotels()
        {
            var temp = wrapperHotels.GetItems();
            return mapper.Map<IEnumerable<Hotels>, IEnumerable<HotelsDTO>>(temp);
        }

        public IEnumerable<ImagesHotelsDTO> GetAllImagesHotels()
        {
            var temp = wrapperImagesHotels.GetItems();
            return mapper.Map<IEnumerable<ImagesHotels>, IEnumerable<ImagesHotelsDTO>>(temp);
        }

        public IEnumerable<ImagesShowPlaceDTO> GetAllImagesShowPlace()
        {
            var temp = wrapperImagesShowPlace.GetItems();
            return mapper.Map<IEnumerable<ImagesShowPlace>, IEnumerable<ImagesShowPlaceDTO>>(temp);
        }

        public IEnumerable<ListClientShowInfoTourDTO> GetAllListClientShowInfoTour()
        {
            var temp = wrapperListClientShowInfoTour.GetItems();
            return mapper.Map<IEnumerable<ListClientShowInfoTour>, IEnumerable<ListClientShowInfoTourDTO>>(temp);
        }

        public IEnumerable<ListOfTouristBuyDTO> GetAllListOfTouristBuy()
        {
            var temp = wrapperListOfTouristBuy.GetItems();
            return mapper.Map<IEnumerable<ListOfTouristBuy>, IEnumerable<ListOfTouristBuyDTO>>(temp);
        }

        public IEnumerable<PersonDTO> GetAllPerson()
        {
            var temp = wrapperPerson.GetItems();
            return mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(temp);
        }

        public IEnumerable<PointInToursDTO> GetAllPointInTours()
        {
            var temp = wrapperPointInTours.GetItems();
            return mapper.Map<IEnumerable<PointInTours>, IEnumerable<PointInToursDTO>>(temp);
        }

        public IEnumerable<ResponsibleForTheToursDTO> GetAllResponsibleForTheTours()
        {
            var temp = wrapperResponsibleForTheTours.GetItems();
            return mapper.Map<IEnumerable<ResponsibleForTheTours>, IEnumerable<ResponsibleForTheToursDTO>>(temp);
        }

        public IEnumerable<ShowPlaceDTO> GetAllShowPlace()
        {
            var temp = wrapperShowPlace.GetItems();
            return mapper.Map<IEnumerable<ShowPlace>, IEnumerable<ShowPlaceDTO>>(temp);
        }

        public IEnumerable<WaysInToursDTO> GetAllWaysInTours()
        {
            var temp = wrapperWaysInTours.GetItems();
            return mapper.Map<IEnumerable<WaysInTours>, IEnumerable<WaysInToursDTO>>(temp);
        }

        public IEnumerable<WaysOfTransportationDTO> GetAllWaysOfTransportation()
        {
            var temp = wrapperWaysOfTransportation.GetItems();
            return mapper.Map<IEnumerable<WaysOfTransportation>, IEnumerable<WaysOfTransportationDTO>>(temp);
        }
        #endregion

        #region REG-Login
        public void Disconect(PersonDTO person)
        {
            users.Remove(users.First(x => x.Person == person));
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
            var tempUsers = mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(wrapperPerson.GetItems());
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
        #endregion

        #region Update
        public void Update(CityDTO item)
        {
            wrapperCity.UpdateItem(mapper.Map<CityDTO, City>(item));
        }

        public void Update(CountryDTO item)
        {
            wrapperCountry.UpdateItem(mapper.Map<CountryDTO, Country>(item));
        }

        public void Update(HotelsDTO item)
        {
            wrapperHotels.UpdateItem(mapper.Map<HotelsDTO, Hotels>(item));
        }

        public void Update(ImagesHotelsDTO item)
        {
            wrapperImagesHotels.UpdateItem(mapper.Map<ImagesHotelsDTO, ImagesHotels>(item));
        }

        public void Update(ImagesShowPlaceDTO item)
        {
            wrapperImagesShowPlace.UpdateItem(mapper.Map<ImagesShowPlaceDTO, ImagesShowPlace>(item));
        }

        public void Update(ListClientShowInfoTourDTO item)
        {
            wrapperListClientShowInfoTour.UpdateItem(mapper.Map<ListClientShowInfoTourDTO, ListClientShowInfoTour>(item));
        }

        public void Update(ListOfTouristBuyDTO item)
        {
            wrapperListOfTouristBuy.UpdateItem(mapper.Map<ListOfTouristBuyDTO, ListOfTouristBuy>(item));
        }

        public void Update(PersonDTO item)
        {
            wrapperPerson.UpdateItem(mapper.Map<PersonDTO, Person>(item));
        }

        public void Update(PointInToursDTO item)
        {
            wrapperPointInTours.UpdateItem(mapper.Map<PointInToursDTO, PointInTours>(item));
        }

        public void Update(ResponsibleForTheToursDTO item)
        {
            wrapperResponsibleForTheTours.UpdateItem(mapper.Map<ResponsibleForTheToursDTO, ResponsibleForTheTours>(item));
        }

        public void Update(ShowPlaceDTO item)
        {
            wrapperShowPlace.UpdateItem(mapper.Map<ShowPlaceDTO, ShowPlace>(item));
        }

        public void Update(ToursDTO item)
        {
            wrapperTours.UpdateItem(mapper.Map<ToursDTO, Tours>(item));
        }

        public void Update(WaysInToursDTO item)
        {
            wrapperWaysInTours.UpdateItem(mapper.Map<WaysInToursDTO, WaysInTours>(item));
        }

        public void Update(WaysOfTransportationDTO item)
        {
            wrapperWaysOfTransportation.UpdateItem(mapper.Map<WaysOfTransportationDTO, WaysOfTransportation>(item));
        }


        #endregion

        public IEnumerable<ToursDTO> getActualTour()
        {
            IEnumerable<Tours> actualTours = new List<Tours>();
            var temp = wrapperTours.GetItems();
            actualTours = (from item in temp
                          where DateTime.Now < item.StartDate  
                          select item).ToList();
            actualTours = (from item in actualTours
                           where item.ListOfTouristBuy.Count < item.MaxTourists
                           select item).ToList();
            return mapper.Map<IEnumerable<Tours>, IEnumerable<ToursDTO>>(actualTours);
        }

        public IEnumerable<ToursDTO> getMyTour(PersonDTO person)
        {
            var test = GetAllListOfTouristBuy();
            var temp = from item in test
                       where item.ClientId == person.Id
                       select item.ToursId;
            List<ToursDTO> resault = new List<ToursDTO>();
            var tempTours = GetAllTours();
            foreach (var item in temp)
            {
                resault.Add(tempTours.First(x => x.Id == item));
            }
            return resault;
        }
    }
}
