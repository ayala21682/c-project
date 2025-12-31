using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class SaleImplementation:ISale
{
    public int Create(Sale sale)
    {
        int myId = DataSource.Config.GetSaleId;
        Sale sale2 =sale with { SaleId = myId };
        DataSource.Sales.Add(sale2);
        return sale2.SaleId;
    }
    public Sale? Read(int SaleId)
    {
        if (DataSource.Sales.Exists((sa) => sa.SaleId == SaleId))
            return DataSource.Sales.Find((sa) => sa.SaleId == SaleId);
        throw new DalIdNotExistsException ("sale is in not the list");
    }
    public List<Sale> ReadAll()
    {
        List<Sale> sale2 = new List<Sale>(DataSource.Sales);
        return sale2;
    }
    public void Update(Sale sale)
    {
         Delete(sale.SaleId);
         DataSource.Sales.Add(sale);
    }
    public void Delete(int SaleId)
    {
        if (DataSource.Sales.Exists((sa) => sa.SaleId == SaleId))
            DataSource.Sales.Remove(DataSource.Sales.Find((sa) => sa.SaleId == SaleId));
        else
            throw new DalIdNotExistsException("sale is in not the list");
    }
}
