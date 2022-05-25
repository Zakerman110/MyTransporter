using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.EntitiyInterface;
using Transport.DAL.Interfaces.IRepositories;

namespace Transport.DAL.Repositories
{
    public abstract class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;

        public GenericRepository(IConnectionFactory connectionFactory, string tableName)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = "GetAllFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<TEntity>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<TEntity> Get(TId Id)
        {
            var query = "GetByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryFirstOrDefaultAsync<TEntity>(query,
                    new { P_tableName = _tableName, P_Id = Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<int> Add(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfProperties = string.Join(", ", columns.Select(e => "@" + e));
            var query = "InsertToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var InsertionStatement = await db.QueryFirstOrDefaultAsync<string>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure);

                var InsertedEntityId = await db.ExecuteScalarAsync<int>(
                    sql: InsertionStatement,
                    param: entity,
                    commandType: CommandType.Text);

                return InsertedEntityId;
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "UpdateInTable";

                var UpdateStatement = await db.QueryFirstOrDefaultAsync<string>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = entity.Id },
                    commandType: CommandType.StoredProcedure);

                await db.ExecuteAsync(
                    sql: UpdateStatement,
                    param: entity,
                    commandType: CommandType.Text);
            }
        }

        public virtual async Task Delete(TEntity entity)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "DeleteFromTable";
                var result = await db.ExecuteAsync(
                    sql: query,
                    param: new { P_tableName = _tableName, P_Id = entity.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType && !(e.PropertyType.IsClass
                            && !e.PropertyType.FullName.StartsWith("System.")))
                    .Select(e => e.Name);
        }
    }
}
