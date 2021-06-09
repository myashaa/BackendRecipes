using System.Threading.Tasks;

namespace BackendRecipes.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
