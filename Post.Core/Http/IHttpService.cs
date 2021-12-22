using System.Net.Http;
using System.Threading.Tasks;
using Post.Core.Dto.Request;

namespace Post.Core.Http
{
    public interface IHttpService
    {
        public Task<RequestDto> GetRequestContent(HttpRequestMessage request);
    }
}