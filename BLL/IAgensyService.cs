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
        IEnumerable<CityDTO> GetAllCitys();

        [OperationContract(IsOneWay = true)]
        void AddItem(CityDTO item);

        //[OperationContract(IsOneWay = true)]
        //void DeleteItem(CityDTO item);

        [OperationContract]
        IEnumerable<ToursDTO> GetAllTours();

        [OperationContract]
        List<CityDTO> GetTour(Tours tours);

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



    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Win(string gameId);
    }



}
