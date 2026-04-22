using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation:BlApi.ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(Sale item)
        {
            return _dal.Sale.Create(item.ConvertBOSaleToDOSale());
        }

        public void Delete(int itemId)
        {
           _dal.Sale.Delete(itemId);
        }

        public Sale? Read(int id)
        {
           
                return _dal.Sale.Read(id).ConvertDOSaleToBOSale();
        }

        public Sale? Read(Func<BO.Sale, bool> filter)
        {
            return _dal.Sale.ReadAll()
                .Select(c => c.ConvertDOSaleToBOSale())
                .FirstOrDefault(filter);
        }

        public List<Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {

            var list = _dal.Sale.ReadAll().Select(p => p.ConvertDOSaleToBOSale());
            if (filter != null)
                list = list.Where(filter);
            return list.ToList()!;

        }

        public List<Sale?> ReadAll()
        {
            var list = _dal.Sale.ReadAll();
            return list.Select(c => c.ConvertDOSaleToBOSale()).ToList()!;


        }

        public void Update(Sale item)
        {
            _dal.Sale.Update(item.ConvertBOSaleToDOSale());
        }
    }
}
