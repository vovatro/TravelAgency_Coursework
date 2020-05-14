using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UI.HelpClasses;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class ShowPlaces : INotifyPropertyChanged
    {
        AgensyServiceClient proxy = null;
        List<ShowPlaceInfo> list_showPlace;
        IEnumerable<CountryDTO> countries;
        IEnumerable<CityDTO> cities;

        public ShowPlaces()
        {
            proxy = new AgensyServiceClient();
            list_showPlace = new List<ShowPlaceInfo>();
            var t = from i in proxy.GetAllImagesShowPlace()
                    join sp in proxy.GetAllShowPlace() on i.Id equals sp.Id
                    join ct in proxy.GetAllCitys() on sp.CityId equals ct.Id
                    join c in proxy.GetAllCountry() on ct.CountryId equals c.Id
                    select new { i.ImageURL, sp.ShowPlaceName, ct.CityName, c.CountryName };
            spi_list = new List<ShowPlaceInfo>();
            countries = proxy.GetAllCountry();
            cities = proxy.GetAllCitys();

            CB_COUNTRY_LIST = new List<string>();
            CB_COUNTRY_LIST.Add("Всі країни");
            SelectCountry = "Всі країни";
            foreach (var item in countries)
            {
                CB_COUNTRY_LIST.Add(item.CountryName);
            }

            


            foreach (var item in t)
            {
                spi_list.Add(new ShowPlaceInfo { IMG = item.ImageURL, NAME = item.ShowPlaceName, CITY = item.CityName, COUNTRY = item.CountryName });
            }
            list_showPlace = spi_list;
        }


        private List<string> cb_country_list;
        public List<string> CB_COUNTRY_LIST
        {
            get
            {
                return cb_country_list;
            }
            set
            {
                cb_country_list = value;
                OnPropertyChanged("CB_COUNTRY_LIST");
            }
        }


        private List<ShowPlaceInfo> spi_list;
        public List<ShowPlaceInfo> SPI_LIST
        {
            get
            {
                return spi_list;
            }
            set
            {
                spi_list = value;
                OnPropertyChanged("SPI_LIST");
            }
        }


        private string selectCountry;
        public string SelectCountry
        {
            get
            {
                return selectCountry;
            }
            set
            {
                selectCountry = value;
                selShowList();
                OnPropertyChanged("SelectCountry");
            }
        }

                

        public async void selShowList()
        {
            if (SelectCountry == "Всі країни")
            {
                spi_list = list_showPlace;
            }
            else
            {
                spi_list.Clear();

                var t = from i in await proxy.GetAllImagesShowPlaceAsync()
                        join sp in await proxy.GetAllShowPlaceAsync() on i.Id equals sp.Id
                        join ct in await proxy.GetAllCitysAsync() on sp.CityId equals ct.Id
                        join c in await proxy.GetAllCountryAsync() on ct.CountryId equals c.Id
                        where c.CountryName == SelectCountry
                        select new { i.ImageURL, sp.ShowPlaceName, ct.CityName, c.CountryName };
                foreach (var item in t)
                {
                    spi_list.Add(new ShowPlaceInfo { IMG = item.ImageURL, NAME = item.ShowPlaceName, CITY = item.CityName, COUNTRY = item.CountryName });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
