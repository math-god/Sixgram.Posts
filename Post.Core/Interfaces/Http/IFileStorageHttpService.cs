using Post.Core.Dto.File;

namespace Post.Core.Interfaces.Http
{
    public interface IFileStorageHttpService
    {
        public Task<string> SendRequest(FileSendingDto data);
    }
}