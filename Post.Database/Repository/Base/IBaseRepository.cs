using Post.Common.Base;

namespace Post.Database.Repository.Base
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        Task<TModel?> GetById(Guid id);
        Task<IEnumerable<TModel>> GetByFilter(Func<TModel, bool> predicate);
        Task<TModel> Create(TModel item);
        Task<TModel> Update(TModel item);
        Task<IEnumerable<TModel>> UpdateRange(List<TModel> items);
        Task<TModel> Delete(TModel item);
    }
}