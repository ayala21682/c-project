using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlApi
{
    public interface ISale
    {
        public int Create(BO.Sale item);
        public BO.Sale? Read(int id);
        public BO.Sale? Read(Func<BO.Sale, bool> filter);
        public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);
        public List<BO.Sale?> ReadAll();
        public void Update(BO.Sale item);
        public void Delete(int itemId);
    }
}
