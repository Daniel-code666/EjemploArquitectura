using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Entitites;

namespace WebApi
{
    public sealed partial class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<IMutableEntityType> entitiesDb = modelBuilder.Model.GetEntityTypes();
            foreach (IMutableEntityType entityType in entitiesDb)
            {
                foreach (IMutableForeignKey relationship in entityType.GetForeignKeys())
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }

                if (entityType.ClrType.IsSubclassOf(typeof(TblCreableEntity)))
                {
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(TblCreableEntity.fecha_creacion))
                        .HasDefaultValueSql("GETDATE()");
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(TblCreableEntity.fecha_modificacion))
                        .HasDefaultValueSql("GETDATE()");
                }
                PropertyInfo? keyProperty = entityType.ClrType.GetProperties()
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));
                if (keyProperty != null && keyProperty.PropertyType == typeof(Guid))
                {
                    modelBuilder.Entity(entityType.ClrType).Property(keyProperty.Name)
                        .HasDefaultValueSql("NEWSEQUENTIALID()");
                }
            }

            modelBuilder.Entity<TblUsersEntity>().Property(r => r.user_password).HasDefaultValue(true);
        }
    }
}
