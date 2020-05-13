using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Wrapper<T> : IWrapper<T> where T : class, IReturnId
    {
        TravelAgencyEntities db;
        DbSet<T> dbSet = null;

        public Wrapper()
        {
            db = new TravelAgencyEntities();
            dbSet = db.Set<T>();
        }

        ~Wrapper()
        {
            db.Dispose();
            db = null;
        }


        public void AddItem(T item)
        {
            dbSet.Add(item);
            Commit();
        }

        public void DeleteItem(T item)
        {
            dbSet.Remove(item);
            Commit();
        }

        public IEnumerable<T> GetItems()
        {
            return dbSet.ToArray();
        }

        public void UpdateItem(T item)
        {
            dbSet.AddOrUpdate(item);
            Commit();
        }

        private void Commit()
        {
            db.SaveChanges();
        }
    }
}
