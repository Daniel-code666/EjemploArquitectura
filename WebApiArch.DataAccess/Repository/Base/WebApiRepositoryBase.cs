using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.Entitites;

namespace WebApi.Repository
{ 
    public class WebApiRepositoryBase<T> where T : class
    {
        protected readonly WebApiDbContext _context;

        protected readonly ILogger<T> _logger;

        public WebApiRepositoryBase(WebApiDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        protected async Task<Guid?> SaveEntityAsync<TEntity>(TEntity entity) where TEntity : TblCreableEntity
        {
            try
            {
                entity.fecha_modificacion = ServerSettings.ObtenerFechaReal();
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return GetEntityId(entity);
            }
            catch (Exception ex)
            {
                HandleException<TEntity>(ex, true);
                return default(Guid?);
            }
        }

        protected virtual Guid? GetEntityId<TEntity>(TEntity entity) where TEntity : class
        {
            PropertyInfo? keyProperty = entity.GetType().GetProperties()
                .FirstOrDefault(p => Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
            if (keyProperty is not null && keyProperty.GetValue(entity) is object prop && (Guid)prop is Guid entity_id && entity_id != default)
                return entity_id;
            else
            {
                String tableName = this.GetTableName<TEntity>();
                _logger.LogError($"(EDB_ID) Error al intentar obtener el id de la entidad {tableName}");
                return default(Guid?);
            }
        }

        protected String GetTableName<TEntity>() where TEntity : class
        {
            IEntityType? entityType = _context.Model.FindEntityType(typeof(TEntity));
            return entityType != null ? Utils.GetSafeString(entityType.GetTableName()) : String.Empty;
        }

        protected void HandleException<TEntity>(Exception ex, Boolean insercion)
            where TEntity : class
        {
            try
            {
                _logger.LogError($"(LOGGER) {GetMessage(ex)}");
                Int16 logs = 0;
                String tipo = insercion ? "insertar" : "actualizar";
                IEnumerable<EntityEntry> entries = _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);
                foreach (EntityEntry entry in entries)
                {
                    if (logs <= 10)
                    {
                        String? propiedades = default;
                        foreach (IProperty prop in entry.CurrentValues.Properties)
                        {
                            if (prop.PropertyInfo is PropertyInfo propInfo && propInfo.GetValue(entry.Entity) is object val)
                                propiedades += $"(Prop: {prop.Name} - Val: {val}), ";
                        }
                        String tableName = this.GetTableName<TEntity>();
                        if (!String.IsNullOrEmpty(propiedades))
                            _logger.LogError($"Error al {tipo} en la tabla: {tableName} - {propiedades}");
                        else
                            _logger.LogError($" Error al {tipo} en la tabla: {tableName} - Ex: {ex.Message}");
                    }
                    _context.Entry(entry.Entity).State = EntityState.Detached;
                    logs++;
                }
                _context.ChangeTracker.Clear();
            }
            catch (Exception ex_handler)
            {
                _logger.LogError($"(EDB_HAN) {GetMessage(ex_handler)}");
                _context.ChangeTracker.Clear();
            }
        }

        private static String GetMessage(Exception ex)
            => ex.InnerException is not null ? $"{ex.Message} - {ex.InnerException.Message}" : ex.Message;
    }
}
