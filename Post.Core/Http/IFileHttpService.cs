using Post.Core.Dto.File;
using Post.Core.Dto.Request;

namespace Post.Core.Http
{
    public interface IFileHttpService
    {
        public Task<string> SendRequest(FileSendingDto fileSendingDto);
    }
}