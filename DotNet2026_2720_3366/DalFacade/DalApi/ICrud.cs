using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
   public interface ICrud<T>
    {
        public int Create(T item);
       public T? Read(int id);
        public T? Read(Func<T, bool> filter);
        public List<T?> ReadAll(Func<T,bool>? filter=null);
        public List<T?> ReadAll();
        public void Update(T item);
        public void Delete(int itemId);
    }
}
