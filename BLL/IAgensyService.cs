using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL;

namespace BLL
{
    [ServiceContract]
    public interface IAgensyService
    {
        [OperationContract]
        IEnumerable<ToursDTO> getActualTour();
        [OperationContract]
        IEnumerable<ToursDTO> getMyTour(PersonDTO person);
        #region AddItem
        [OperationContract(IsOneWay = true,Name = "AddItemCity")]
        void AddItem(CityDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemCountry")]
        void AddItem(CountryDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemHotels")]
        void AddItem(HotelsDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemImagesHotels")]
        void AddItem(ImagesHotelsDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemImagesShowPlace")]
        void AddItem(ImagesShowPlaceDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemListClientShowInfoTour")]
        void AddItem(ListClientShowInfoTourDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemListOfTouristBuy")]
        void AddItem(ListOfTouristBuyDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemPerson")]
        void AddItem(PersonDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemPointInTours")]
        void AddItem(PointInToursDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemResponsibleForTheTours")]
        void AddItem(ResponsibleForTheToursDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemShowPlace")]
        void AddItem(ShowPlaceDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemTours")]
        void AddItem(ToursDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemWaysInTours")]
        void AddItem(WaysInToursDTO item);
        [OperationContract(IsOneWay = true, Name = "AddItemWaysOfTransportation")]
        void AddItem(WaysOfTransportationDTO item);

        #endregion
        //[OperationContract(IsOneWay = true)]
        //void DeleteItem(CityDTO item);
        #region GetAll
        [OperationContract]
        IEnumerable<CityDTO> GetAllCitys();
        [OperationContract]
        IEnumerable<ToursDTO> GetAllTours();
        [OperationContract]
        IEnumerable<CountryDTO> GetAllCountry();
        [OperationContract]
        IEnumerable<HotelsDTO> GetAllHotels();
        [OperationContract]
        IEnumerable<ImagesHotelsDTO> GetAllImagesHotels();
        [OperationContract]
        IEnumerable<ImagesShowPlaceDTO> GetAllImagesShowPlace();
        [OperationContract]
        IEnumerable<ListClientShowInfoTourDTO> GetAllListClientShowInfoTour();
        [OperationContract]
        IEnumerable<ListOfTouristBuyDTO> GetAllListOfTouristBuy();
        [OperationContract]
        IEnumerable<PersonDTO> GetAllPerson();
        [OperationContract]
        IEnumerable<PointInToursDTO> GetAllPointInTours();
        [OperationContract]
        IEnumerable<ResponsibleForTheToursDTO> GetAllResponsibleForTheTours();
        [OperationContract]
        IEnumerable<ShowPlaceDTO> GetAllShowPlace();
        [OperationContract]
        IEnumerable<WaysInToursDTO> GetAllWaysInTours();
        [OperationContract]
        IEnumerable<WaysOfTransportationDTO> GetAllWaysOfTransportation();
        #endregion

        #region REG-Login
        [OperationContract(IsOneWay = true)]
        void Registration(PersonDTO person);

        [OperationContract]
        PersonDTO Login(string login, string password);

        [OperationContract]
        bool IsPersonOnline(PersonDTO person);
        [OperationContract]
        bool IsUniqueLogin(string login);

        [OperationContract(IsOneWay = true)]
        void Disconect(PersonDTO person);
        #endregion

        #region Update
        [OperationContract(IsOneWay = true,Name = "UpdateCity")]
        void Update(CityDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateCountry")]
        void Update(CountryDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateHotels")]
        void Update(HotelsDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateImageHotels")]
        void Update(ImagesHotelsDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateImageShowPlace")]
        void Update(ImagesShowPlaceDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateListClientShowInfoTour")]
        void Update(ListClientShowInfoTourDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateListOfTouristBuy")]
        void Update(ListOfTouristBuyDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdatePerson")]
        void Update(PersonDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdatePointInTours")]
        void Update(PointInToursDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateResponsibleForTheTours")]
        void Update(ResponsibleForTheToursDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateShowPlace")]
        void Update(ShowPlaceDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateTours")]
        void Update(ToursDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateWaysInTours")]
        void Update(WaysInToursDTO item);
        [OperationContract(IsOneWay = true, Name = "UpdateWaysOfTransportation")]
        void Update(WaysOfTransportationDTO item);
        #endregion
    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Win(string gameId);
    }



}
