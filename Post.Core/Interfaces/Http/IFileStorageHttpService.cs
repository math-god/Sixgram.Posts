using System.Net;
using Post.Core.Dto.File;

namespace Post.Core.Interfaces.Http
{
    public interface IFileStorageHttpService
    {
        public Task<string?> SendCreateRequest(FileSendingDto data);
        public Task<HttpStatusCode?> SendDeleteRequest(Guid fileId);
    }
}