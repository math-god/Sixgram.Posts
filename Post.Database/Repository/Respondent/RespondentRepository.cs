using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Respondent;

public class RespondentRepository : BaseRepository<RespondentModel>, IRespondentRepository
{
    public RespondentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}