using DAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.TAContext;

namespace DAL
{
    public class Wrapper<T> : IWrapper<T> where T : class
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
            //try
            //{
            //    var tempItem = Find(item);
            //    db.Entry(tempItem).State = System.Data.Entity.EntityState.Deleted;
            //    Commit();
            //}
            //catch (ArgumentNullException ex)
            //{
            //    throw;
            //}
        }

        public T Find(T entry)
        {
            Client cl = new Client();
            if (entry.GetType() == cl.GetType())
            {
                var tempItem = dbSet.FirstOrDefault(x => (x as Client).Email.Equals((entry as Client).Email));
                if (tempItem != null)
                    return tempItem;
            }
            throw new ArgumentNullException();
        }

        public IEnumerable<T> GetItems()
        {
            return dbSet.ToArray();
        }

        public void UpdateItem(T item)
        {
            //try
            //{
            //    var tempItem = Find(item);
            //    tempItem = tempItem;
            //    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            //    Commit();
            //}
            //catch (ArgumentNullException ex)
            //{
            //    throw;
            //}
        }





        private void Commit()
        {
            db.SaveChanges();
        }
    }
}
