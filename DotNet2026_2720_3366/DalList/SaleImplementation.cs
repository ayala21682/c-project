using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class SaleImplementation : ISale
{
    public int Create(Sale sale)
    {

        //int myId = DataSource.Config.GetSaleId;
        //Sale sale2 = sale with { SaleId = myId };
        //DataSource.Sales.Add(sale2);
        //return sale2.SaleId;
    
        int newId = DataSource.Config.GetSaleId;

        Sale saleWithId = sale with { SaleId = newId };

        DataSource.Sales.Add(saleWithId);

        return newId;
    
    }
    public Sale? Read(int id)
    {
        if (DataSource.Sales.Exists(sa => sa != null && sa.SaleId == id))
            return DataSource.Sales.Find(sa => sa.SaleId == id);
        else
            throw new DalIdNotExistsException("sale is not in the list");
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        var sale = DataSource.Sales.FirstOrDefault(filter);

        if (sale == null)
            throw new DalIdNotExistsException("sale is not in the list");

        return sale;
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        var query = DataSource.Sales.AsEnumerable();
        if (filter != null)
            query = query.Where(filter);
        return query.ToList();
    }
    public List<Sale?> ReadAll()
    {
        return DataSource.Sales.ToList();
    }

    public void Update(Sale sale)
    {
        Delete(sale.SaleId);
        DataSource.Sales.Add(sale);
    }
    public void Delete(int SaleId)
    {
        //if (DataSource.Sales.Exists((sa) => sa.SaleId == SaleId))
        //    DataSource.Sales.Remove(DataSource.Sales.Find((sa) => sa.SaleId == SaleId));
        //else
        //    throw new DalIdNotExistsException("sale is in not the list");
        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == SaleId);
        if (sale == null)
            throw new DalIdNotExistsException("Sale is not in the list");

        DataSource.Sales.Remove(sale);

    }
}

