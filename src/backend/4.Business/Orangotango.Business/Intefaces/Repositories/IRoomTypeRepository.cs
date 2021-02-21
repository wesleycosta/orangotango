using Orangotango.Business.Models;
using System;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Repositories
{
    public interface IRoomTypeRepository : IRepositoryBase<RoomType>
    {
        Task<bool> HasName(string name);
        Task<bool> HasNameAndHasTheRightId(string name, Guid id);
    }
}
