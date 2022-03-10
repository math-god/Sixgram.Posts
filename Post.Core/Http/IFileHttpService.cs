using Post.Core.Dto.File;

namespace Post.Core.Http
{
    public interface IFileHttpService
    {
        public Task<string> SendRequest(FileSendingDto data);
    }
}