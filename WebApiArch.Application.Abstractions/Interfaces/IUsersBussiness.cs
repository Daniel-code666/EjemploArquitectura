using WebApi.Objects;

namespace WebApi.Interfaces
{
    public interface IUsersBussiness
    {
        Task<IEnumerable<UsersRead?>> GetAllUsers();
        Task<Guid?> CreateUser(UsersCreate user);
    }
}
