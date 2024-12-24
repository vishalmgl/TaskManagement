using System.Threading.Tasks;

namespace TaskManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        Task RefreshAsync();
    }
}
