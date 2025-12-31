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
        public T? Read(int itemId);
        public List<T> ReadAll();
        public void Update(T item);
        public void Delete(int itemId);
    }
}
