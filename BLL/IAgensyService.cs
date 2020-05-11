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
        void AddItem(City item);
        [OperationContract(IsOneWay = true)]
        void DeleteItem(City item);
        [OperationContract]
        IEnumerable<ToursDTO> GetAllTours();
        [OperationContract]
        List<CityDTO> GetTour(Tours tours);
        [OperationContract]
        Person Login();
        [OperationContract]
        void Disconect(Person user);

    }


    
}
