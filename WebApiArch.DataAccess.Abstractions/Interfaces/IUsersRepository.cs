using WebApi.Entitites;

namespace WebApi.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<TblUsersEntity?>> GetAllUsers();
        Task<Guid?> CreateUser(TblUsersEntity user);
    }
}
