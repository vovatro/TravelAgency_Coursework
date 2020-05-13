using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.HelpClasses;
using UI.ServiceReference1;

namespace UI.Classes
{
    //public class ShowPlaces : INotifyPropertyChanged
    //{
    //    AgensyServiceClient proxy = null;
    //    List<ShowPlaceInfo> list_showPlace;
    //    List<Country> countries;
    //    public string selectCountry { get; set; }

    //    public ShowPlaces()
    //    {
    //        proxy = new AgensyServiceClient();
    //        countries = new List<Country>();
    //        list_showPlace = new List<ShowPlaceInfo>();
    //        //var t = from i in proxy.GetShowPlaceImg()
    //        //        join sp in proxy.GetShowPlace() on i.Id equals sp.Id
    //        //        join ct in proxy.GetCities() on sp.CityId equals ct.Id
    //        //        join c in proxy.GetCountryes() on ct.CountryId equals c.Id
    //        //        select new { i.ImageURL, sp.ShowPlaceName, ct.CityName, c.CountryName };
    //        spi_list = new List<ShowPlaceInfo>();
    //        //countries = h.GetCountryes();
    //        cb_country_list = new List<string>();
    //        cb_country_list.Add("Всі країни");
    //        selectCountry = "Всі країни";
    //        foreach (var item in countries)
    //        {
    //            cb_country_list.Add(item.CountryName);
    //        }

    //        //foreach (var item in t)
    //        //{
    //        //    spi_list.Add(new ShowPlaceInfo { IMG = item.ImageURL, NAME = item.ShowPlaceName, CITY = item.CityName, COUNTRY = item.CountryName });
    //        //}
    //        list_showPlace = spi_list;
    //    }

    //    private List<string> cb_country_list;
    //    public List<string> CB_COUNTRY_LIST
    //    {
    //        get
    //        {
    //            return cb_country_list;
    //        }
    //        set
    //        {
    //            cb_country_list = value;
    //            OnPropertyChanged("CB_COUNTRY_LIST");
    //        }
    //    }

    //    private List<ShowPlaceInfo> spi_list;
    //    public List<ShowPlaceInfo> SPI_LIST
    //    {
    //        get
    //        {
    //            return spi_list;
    //        }
    //        set
    //        {
    //            spi_list = value;
    //            OnPropertyChanged("SPI_LIST");
    //        }
    //    }

    //    public void selCountry()
    //    {
    //        if (selectCountry == "Всі країни")
    //        {
    //            spi_list = list_showPlace;
    //        }
    //        //else
    //        //{
    //        //    var t = from i in h.GetShowPlaceImg()
    //        //            join sp in h.GetShowPlace() on i.Id equals sp.Id
    //        //            join ct in h.GetCities() on sp.CityId equals ct.Id
    //        //            join c in h.GetCountryes() on ct.CountryId equals c.Id
    //        //            where c.CountryName == selectCountry
    //        //            select new { i.ImageURL, sp.ShowPlaceName, ct.CityName, c.CountryName };
    //        //    spi_list.Clear();
    //            //foreach (var item in t)
    //            //{
    //            //    spi_list.Add(new ShowPlaceInfo { IMG = item.ImageURL, NAME = item.ShowPlaceName, CITY = item.CityName, COUNTRY = item.CountryName });
    //            //}
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged([CallerMemberName]string prop = "")
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    //    }
    //}
}
