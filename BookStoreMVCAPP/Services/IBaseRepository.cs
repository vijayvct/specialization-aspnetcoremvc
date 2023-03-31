namespace BookStoreMVCAPP.Services
{
    public interface IBaseRepository<T> 
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(int? id);
        T Get(int? id);
        List<T> GetAll();
    }
}
