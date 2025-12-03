
namespace DalFacade.DO;
public record Product(int ProductId, string ProductName, Enum ProductCategorey,double Price,int Amount)
{ }
 public record Custumer(int CustomerId, string CustomerName,string? Address,string? PhoneNumber)
{

}
public record Sale(int SaleId, int ProductId,int RequiredAmount,double SalePrice,bool ForAllCustomers,DateTime BeginSale,DateTime EndSale)
{

}