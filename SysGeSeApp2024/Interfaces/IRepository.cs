using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(long id);
        Task Adicionar(TEntity entity);

        Task Atualizar(TEntity entity);

        Task Remover(int id);
        Task<int> SaveChanges();
    }
}
