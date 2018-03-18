using Newtonsoft.Json;
using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class HotSpotController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string targetUrl = "http://data.ntpc.gov.tw/od/data/api/04958686-1B92-4B74-889D-9F34409B272B?$format=json";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            var response = await client.GetStringAsync(targetUrl);

            //ViewBag.Result = response;
            var collection = JsonConvert.DeserializeObject<IEnumerable<HotSpotViewModel>>(response);

            return View(collection);
        }
    }
}