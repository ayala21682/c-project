

namespace DalApi;
using DO;
public interface ISale : ICrud<Sale>
{
    public int Create(Sale item);
    public Sale? Read(int id);
    public Sale? Read(Func<Sale, bool> filter);
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null);
    public List<Sale?> ReadAll();
    public void Update(Sale item);
    public void Delete(int itemId);
}

