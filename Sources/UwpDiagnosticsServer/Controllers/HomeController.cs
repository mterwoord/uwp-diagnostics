using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace UwpDiagnosticsServer.Controllers
{
    public class HomeController: ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(mContent);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {
            mContent = await Request.Content.ReadAsStringAsync();
            return Ok();
        }

        private static volatile string mContent = "";
    }
}