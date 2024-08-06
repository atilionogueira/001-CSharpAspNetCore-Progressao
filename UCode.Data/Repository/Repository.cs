using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }


        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        }
        
        /*
        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet.AsNoTracking().Where(predicate);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }
        
        */

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {

            // DbSet.Update(entity);
            // await SaveChanges();  
            var existingEntity = await DbSet.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                Db.Entry(existingEntity).CurrentValues.SetValues(entity);
                await SaveChanges();
            }
            else
            {
                // Tratar o caso em que a entidade não existe
                throw new KeyNotFoundException("Entity not found for update.");
                // Ou você pode logar uma mensagem, retornar um código de erro, etc.
            }
        }

        public virtual async Task Remover(Guid id)
        {
            {
                DbSet.Remove(new TEntity { Id = id });
                await SaveChanges();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
