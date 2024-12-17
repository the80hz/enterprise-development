namespace Staff.Domain.Repositories;

public interface IRepository<T>
{
    public IEnumerable<T> GetAll();
    public T? GetById(int id);
    public T? Post(T entity);
    public bool Put(T entity);
    public bool Delete(int id);
}