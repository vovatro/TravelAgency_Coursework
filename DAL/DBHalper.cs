using DAL.TAContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHalper
    {
        #region AgenWork_GET_SET_ADD
        public List<AgencyWorker> GetWorker()
        {
            List<AgencyWorker> temp = new List<AgencyWorker>();

            using (TravelAgencyEntities db = new TravelAgencyEntities())
            {
                temp = (from i in db.AgencyWorkers
                        select i).ToList();
            }
            return temp;
        }

        public void SetWorker(int _id, string _FIO, string _position, string _email, string _phone, DateTime _dayOfRecrut)
        {
            var temp = new AgencyWorker
            {
                Id = _id,
                FIO = _FIO,
                Position = _position,
                Email = _email,
                PhoneNumber = _phone,
                DateOfRecruitment = _dayOfRecrut.Date
            };

            using (TravelAgencyEntities db = new TravelAgencyEntities())
            {
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void AddWorker(string _FIO, string _position, string _email, string _phone, DateTime _dayOfRecrut)
        {
            using (TravelAgencyEntities db = new TravelAgencyEntities())
            {
                db.AgencyWorkers.Add(new AgencyWorker
                {
                    FIO = _FIO,
                    Position = _position,
                    Email = _email,
                    PhoneNumber = _phone,
                    DateOfRecruitment = _dayOfRecrut.Date
                });

                db.SaveChanges();
            }
        }
        #endregion



    }
}
