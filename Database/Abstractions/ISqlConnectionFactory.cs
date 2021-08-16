using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Abstractions
{
    public interface ISqlConnectionFactory
    {
        Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken = default);
    }
}
