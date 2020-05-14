using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBLL.ServiceReference1;

namespace TestBLL
{
    class Program
    {
        static void Main(string[] args)
        {
            AgensyServiceClient client = new AgensyServiceClient();


            //var temp = client.GetAllTours();
            //ToursDTO toursdto = temp.First(x => x.Id == 6);
            //toursdto.MaxTourists = 15;
            //client.UpdateTours(toursdto);

            //var tempTours = client.getActualTour();
            //foreach (var item in tempTours)
            //{
            //    Console.Write(item.Id);
            //    Console.Write(" ");
            //    Console.Write(item.TourName);
            //    Console.Write(" ");
            //    Console.Write(item.StartDate);
            //    Console.Write(" ");
            //    Console.Write(item.MaxTourists);
            //    Console.WriteLine();
            //}
            var tempPersons = client.GetAllPerson();
            foreach (var item in tempPersons)
            {
                Console.Write(item.Id + " ");
                Console.Write(item.FirstName + " " + item.LastName + " " + item.SurName);
                Console.WriteLine();
                foreach (var i in client.getMyTour(item))
                {
                    Console.Write("---");
                    Console.Write(i.Id + " ");
                    Console.Write(i.TourName + " " + i.Price + " " + i.MaxTourists);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("End");
        }
        
    }


}
