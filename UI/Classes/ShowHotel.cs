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
    public class ShowHotel : INotifyPropertyChanged
    {
        AgensyServiceClient proxy = null;
        List<HotelInfo> list_showHotel;
        IEnumerable<CountryDTO> countries;
        IEnumerable<CityDTO> cities;

        public ShowHotel()
        {
            //cb_selCountry = new CB_selectCountry(this);
            proxy = new AgensyServiceClient();
            //countries = new IEnumerable<CountryDTO>;
            list_showHotel = new List<HotelInfo>();
            var t = from i in proxy.GetAllImagesHotels()
                    join h in proxy.GetAllHotels() on i.Id equals h.Id
                    join ct in proxy.GetAllCitys() on h.CityId equals ct.Id
                    join c in proxy.GetAllCountry() on ct.CountryId equals c.Id
                    select new { i.ImageURL, h.HotelsName, ct.CityName, c.CountryName };
            hotel_list = new List<HotelInfo>();
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
                hotel_list.Add(new HotelInfo { IMG = item.ImageURL, NAME = item.HotelsName, CITY = item.CityName, COUNTRY = item.CountryName });
            }
            list_showHotel = hotel_list;
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


        private List<HotelInfo> hotel_list;
        public List<HotelInfo> Hotel_list
        {
            get
            {
                return hotel_list;
            }
            set
            {
                hotel_list = value;
                OnPropertyChanged("Hotel_list");
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



        public void selShowList()
        {
            if (SelectCountry == "Всі країни")
            {
                hotel_list = list_showHotel;
            }
            else
            {
                hotel_list.Clear();
                var t = from i in proxy.GetAllImagesHotels()
                        join h in proxy.GetAllHotels() on i.Id equals h.Id
                        join ct in proxy.GetAllCitys() on h.CityId equals ct.Id
                        join c in proxy.GetAllCountry() on ct.CountryId equals c.Id
                        where c.CountryName == SelectCountry
                        select new { i.ImageURL, h.HotelsName, ct.CityName, c.CountryName };
                foreach (var item in t)
                {
                    hotel_list.Add(new HotelInfo { IMG = item.ImageURL, NAME = item.HotelsName, CITY = item.CityName, COUNTRY = item.CountryName });
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
