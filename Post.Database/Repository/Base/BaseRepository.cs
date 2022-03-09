using Microsoft.EntityFrameworkCore;
using Post.Common.Base;

namespace Post.Database.Repository.Base
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected readonly AppDbContext AppDbContext;

        protected BaseRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public async Task<TModel> GetById(Guid id)
            => await AppDbContext.Set<TModel>().AsNoTracking().FirstAsync(p => p.Id == id);

        public async Task<IEnumerable<TModel>> GetByFilter(Func<TModel, bool> predicate)
        {
            var result = await AppDbContext.Set<TModel>().AsNoTracking().
                Where(predicate).AsQueryable().ToListAsync();
            return result;
        }

        public async Task<TModel> Create(TModel item)
        {
            await AppDbContext.Set<TModel>().AddAsync(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Update(TModel item)
        {
            AppDbContext.Set<TModel>().Update(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<TModel>> UpdateRange(List<TModel> item)
        {
            AppDbContext.Set<TModel>().UpdateRange(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Delete(TModel item)
        {
            AppDbContext.Set<TModel>().Remove(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }
    }
}