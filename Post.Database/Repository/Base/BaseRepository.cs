using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Post.Common.Base;

namespace Post.Database.Repository.Base
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel 
    {
        private readonly AppDbContext _appDbContext;

        protected BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TModel?> GetById(Guid id)
            => await _appDbContext.Set<TModel>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<TModel>> GetByFilter(Expression<Func<TModel, bool>> predicate)
        {
            var result = await GetAll().AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
            return result;
        }

        public async Task<TModel> Create(TModel item)
        {
            item.DateCreated = DateTime.Now;
            await _appDbContext.Set<TModel>().AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Update(TModel item)
        {
            _appDbContext.Set<TModel>().Update(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<TModel>> UpdateRange(List<TModel> item)
        {
            _appDbContext.Set<TModel>().UpdateRange(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Delete(TModel item)
        {
            _appDbContext.Set<TModel>().Remove(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        private IQueryable<TModel> GetAll()
        {
            return _appDbContext.Set<TModel>().AsQueryable();
        }
    }
}