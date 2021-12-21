using System.Net.Http;
using System.Threading.Tasks;

namespace Post.Core.Http
{
    public interface IHttpService
    {
        public Task<string> GetRequestContent();
    }
}