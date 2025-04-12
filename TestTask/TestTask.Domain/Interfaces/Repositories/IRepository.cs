namespace TestTask.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Adds a new entity to the database.
        Task CreateAsync(TEntity entity);

        //Updates an existing entity in the database.
        Task UpdateAsync(TEntity entity);

        // Deletes an entity by its unique identifier.
        Task DeleteAsync(Guid id);

        // Retrieves all entities.
        Task<IEnumerable<TEntity>> GetAllAsync();

        //Retrieves an entity by its unique identifier.
        Task<TEntity?> GetByIdAsync(Guid id);
    }
}
