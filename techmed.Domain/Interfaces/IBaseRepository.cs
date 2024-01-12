namespace Techmed.Interfaces;
using Techmed.Entities;
public interface IBaseRepository<T> where T : Pessoa
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
