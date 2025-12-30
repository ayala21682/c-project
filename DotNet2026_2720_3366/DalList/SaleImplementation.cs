using DO;
using DalApi;


    namespace Dal;

internal class SaleImplementation:ISale
{
    public int Create(Sale sale)
    {
        if (!(DataSource.Sales.Exists((sa) => sa.SaleId == sale.SaleId)))
            DataSource.Sales.Add(sale);
        throw new NotImplementedException("sale is in the list");
    }
    public Sale? Read(int SaleId)
    {
        if (DataSource.Sales.Exists((sa) => sa.SaleId == SaleId))
            return DataSource.Sales.Find((sa) => sa.SaleId == SaleId);
        throw new NotImplementedException("sale is in not the list");
    }
    public List<Sale> ReadAll()
    {
        return DataSource.Sales;
    }
    public void Update(Sale sale)
    {
        if (DataSource.Sales.Exists((sa) => sa.SaleId == sale.SaleId))
            DataSource.Sales[DataSource.Sales.FindIndex((sa) => sa.SaleId == sale.SaleId)] = sale;

    }
    public void Delete(int SaleId)
    {
        if (DataSource.Sales.Exists((sa) => sa.SaleId == SaleId))
            DataSource.Sales.Remove(DataSource.Sales.Find((sa) => sa.SaleId == SaleId));
    }
}
