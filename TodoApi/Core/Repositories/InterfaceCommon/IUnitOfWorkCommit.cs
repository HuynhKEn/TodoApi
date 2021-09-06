using System.Threading.Tasks;

namespace TodoApi.Core.Repositories.InterfaceCommon {
    public interface IUnitOfWorkCommit {
        Task<int> CommitAsync();
    }
}
