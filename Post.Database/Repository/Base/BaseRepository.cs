using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<TModel> Delete(Guid id)
        {
            var item = await AppDbContext.Set<TModel>().FindAsync(id);
            if (item == null)
                return null;

            AppDbContext.Set<TModel>().Remove(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }
    }
}