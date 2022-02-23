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

        public IEnumerable<TModel> GetAllObjects()
            => AppDbContext.Set<TModel>().AsNoTracking().ToList();

        public async Task<TModel> GetById(Guid id)
            => await AppDbContext.Set<TModel>().FindAsync(id);

        public IEnumerable<TModel> GetByFilter(Func<TModel, bool> predicate)
            => AppDbContext.Set<TModel>().Where(predicate);

        public virtual async Task<TModel> Create(TModel item)
        {
            /*item.DateCreated = DateTime.Now;*/
            await AppDbContext.Set<TModel>().AddAsync(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Update(TModel item)
        {
            /*item.DateUpdated = DateTime.Now;*/
            AppDbContext.Set<TModel>().Update(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<TModel>> UpdateRange(List<TModel> item)
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