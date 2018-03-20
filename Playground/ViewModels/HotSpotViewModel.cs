using PagedList;
using System.ComponentModel.DataAnnotations;

namespace Playground.ViewModels
{
    public class HotSpotViewModel : IPage
    {
        public IPagedList<HotSpotItem> Items { get; set; }

        public string Dist { get; set; }

        public int PageNum { get; set; } = 1;   
    }

    public class HotSpotItem
    {
        [Display(Name = "編號")]
        public string id { get; set; }
        [Display(Name = "名稱")]
        public string spot_name { get; set; }
        [Display(Name = "縣市")]
        public string type { get; set; }
        [Display(Name = "電信公司")]
        public string company { get; set; }
        [Display(Name = "區域")]
        public string district { get; set; }
        [Display(Name = "地址")]
        public string address { get; set; }
        [Display(Name = "")]
        public string apparatus_name { get; set; }
        [Display(Name = "緯度")]
        public string latitude { get; set; }
        [Display(Name = "經度")]
        public string longitude { get; set; }
    }

    interface IPage{
        int PageNum { get; set; }
    }
}