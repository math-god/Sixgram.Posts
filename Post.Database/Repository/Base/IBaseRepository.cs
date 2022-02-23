using Post.Common.Base;

namespace Post.Database.Repository.Base
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        IEnumerable<TModel> GetAllObjects();
        Task<TModel> GetById(Guid id);
        IEnumerable<TModel> GetByFilter(Func<TModel, bool> predicate);
        Task<TModel> Create(TModel item);
        Task<TModel> Update(TModel item);
        Task<List<TModel>> UpdateRange(List<TModel> items);
        Task<TModel> Delete(TModel item);
    }
}