using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Infrastructure.Data.Common
{
    /// <summary>
    /// Abstraction of repository access methods
    /// </summary>
    /// <typeparam name="T">Repository type / db table</typeparam>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>() where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T?> GetByIdAsync<T>(object id) where T : class;

        /// <summary>
        /// Gets specifi record from database by primary key
        /// </summary>
        /// <param name="id">Composite key</param>
        /// <returns>Single record</returns>
        Task<T?> GetByIdsAsync<T>(object[] id) where T : class;

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable list of entities</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="id">Identificator of record to be deleted</param>
        Task DeleteAsync<T>(object id) where T : class;

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted</param>
        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(IEnumerable<T> entities) where T : class;


        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <param name="entity">Entity to be detached</param>
        void Detach<T>(T entity) where T : class;

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Executes stored procedure
        /// </summary>
        /// <typeparam name="T">Return type of stored procedure</typeparam>
        /// <param name="procedure">Procedure from enum</param>
        /// <param name="args">Procedure parameters</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteProc<T>(ProcedureType procedure, params object[] args) where T : class;

        /// <summary>
        /// Executes raw SQL query
        /// </summary>
        /// <typeparam name="T">Query return type</typeparam>
        /// <param name="query">Query string (do not include user input!!!) 
        /// basic SQL injection check will be aplied</param>
        /// <param name="args">Query parameters (will be sanitized through NpgsqlParameter)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if unsafe query detected</exception>
        IQueryable<T> ExecuteSQL<T>(FormattableString query) where T : class;

        [Obsolete("Use ExecuteSQL instead")]
        IQueryable<T> ExecuteRawSQL<T>(string query) where T : class;

        /// <summary>
        /// Deletes records imediately from database without tracking
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="search">Predicate</param>
        /// <returns></returns>
        Task<int> DeleteAsNoTrackingAsync<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// Deletes records from database with tracking
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <param name="search">Predicate</param>
        /// <returns></returns>
        Task DeleteAsync<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// Truncate table
        /// </summary>
        /// <param name="table">Table name</param>
        public Task Truncate(string table);

        /// <summary>
        /// Clear change tracker
        /// </summary>
        void ChangeTrackerClear();
    }
}
