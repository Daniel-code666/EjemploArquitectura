using Microsoft.EntityFrameworkCore;
using WebApi.Entitites;

namespace WebApi
{
    public sealed partial class WebApiDbContext
    {
        public DbSet<TblUsersEntity> Users { get; set; } = null!;
    }
}
