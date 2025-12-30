

namespace DalApi;
using DO;
public interface ISale
{

    int Create(Sale sale);
    Sale? Read(int SaleId);
    List<Sale> ReadAll();
    void Update(Sale sale);
    void Delete(int SaleId);
}
