using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Entitites;
using WebApi.Interfaces;

namespace WebApi.Repository
{
    public class UsersRepository : WebApiRepositoryBase<UsersRepository>, IUsersRepository
    {
        public UsersRepository(WebApiDbContext context, ILogger<UsersRepository> logger) : base(context, logger)
        {
        }

        async Task<IEnumerable<TblUsersEntity?>> IUsersRepository.GetAllUsers()
            => await _context.Users.ToListAsync();

        Task<Guid?> IUsersRepository.CreateUser(TblUsersEntity user)
            => base.SaveEntityAsync(user);
    }
}
