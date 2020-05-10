using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWrapper<T>
    {
        IEnumerable<T> GetItems();
        // T Find(T entry);
        void UpdateItem(T item);
        void AddItem(T item);
        void DeleteItem(T item);
    }
}
