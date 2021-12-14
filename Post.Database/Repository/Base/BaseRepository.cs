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
        private readonly AppDbContext _appDbContext;

        protected BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TModel> GetAllObjects()
            => _appDbContext.Set<TModel>().AsNoTracking().ToList();

        public async Task<TModel> GetById(Guid id)
            => await _appDbContext.Set<TModel>().FindAsync(id);

        public async Task<TModel> Create(TModel item)
        {
            item.DateCreated = DateTime.Now;
            await _appDbContext.Set<TModel>().AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Update(TModel item)
        {
            item.DateUpdated = DateTime.Now;
            _appDbContext.Set<TModel>().Update(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TModel> Delete(Guid id)
        {
            var item = await _appDbContext.Set<TModel>().FindAsync(id);
            if (item == null)
                return null;

            _appDbContext.Set<TModel>().Remove(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
    }
}