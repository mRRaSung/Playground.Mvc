using Newtonsoft.Json;
using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;

namespace Playground.Controllers
{
    public class HotSpotController : Controller
    {
        private int PageSize = 10;

        [Route("~/HotSpot/{dist:regex(^[\u4E00-\u9fa5]+)}/{pageNum:int?}", Order = 1)]
        [Route("~/HotSpot/{pageNum:int?}", Order = 2)]
        //[OutputCache(Duration = 300, VaryByParam = "*")]
        public async Task<ActionResult> Index(HotSpotViewModel model)
        {
            //string targetUrl = "http://data.ntpc.gov.tw/od/data/api/04958686-1B92-4B74-889D-9F34409B272B?$format=json";

            //HttpClient client = new HttpClient();
            //client.MaxResponseContentBufferSize = Int32.MaxValue;

            //var response = await client.GetStringAsync(targetUrl);

            ////ViewBag.Result = response;
            //var collection = JsonConvert.DeserializeObject<IEnumerable<HotSpotViewModel>>(response);

            //return View(collection);

            //Districts
            ViewBag.Districts = await this.DistrictSelectList(model.Dist);

            var result = await GetHotSpotData();

            if (!string.IsNullOrWhiteSpace(model.Dist)){
                result = result.Where(x => x.district == model.Dist);
            }

            model.Items = result.ToPagedList(model.PageNum, PageSize);

            return View(model);
        }

        private async Task<IEnumerable<HotSpotItem>> GetHotSpotData()
        {
            //try to get cache exist
            string cacheName = "WIFI_HOTSPOT";
            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveHotSpotData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<HotSpotItem>;
            }
        }

        private async Task<IEnumerable<HotSpotItem>> RetriveHotSpotData(string cacheName)
        {
            string targetURI = "http://data.ntpc.gov.tw/od/data/api/04958686-1B92-4B74-889D-9F34409B272B?$format=json";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var response = await client.GetStringAsync(targetURI);
            var collection = JsonConvert.DeserializeObject<IEnumerable<HotSpotItem>>(response);

            //init cache
            ObjectCache cacheItem = MemoryCache.Default;

            //set policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            
            //set cache
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }


        private async Task<List<string>> GetDistricts()
        {
            var data = await GetHotSpotData();

            if(data != null)
            {
                var districts = data.OrderBy(x => x.district)
                                    .Select(x => x.district)
                                    .Distinct();

                return districts.ToList();
            }

            return new List<string>();
        }

        private async Task<IEnumerable<SelectListItem>> DistrictSelectList(string district)
        {
            List<string> listDistricts = await GetDistricts();

            IEnumerable<SelectListItem> selectListDistricts = listDistricts.Select(x => new SelectListItem
            {
                Text = x,
                Value = x,
                Selected = !string.IsNullOrEmpty(district)
                           && x.Equals(district, StringComparison.OrdinalIgnoreCase)
            });

            return selectListDistricts;
        }
    }
}