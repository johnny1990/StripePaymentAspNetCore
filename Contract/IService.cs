using Models;

namespace Contract
{
    public interface IService
    {
        IEnumerable<TShirt> GetAll();
        TShirt GetById(Guid cId);
    }
}