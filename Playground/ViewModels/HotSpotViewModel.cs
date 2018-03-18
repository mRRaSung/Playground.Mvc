using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Playground.ViewModels
{
    public class HotSpotViewModel
    {
        [Display(Name = "編號")]
        public string id { get; set; }
        [Display(Name = "名稱")]
        public string spot_name { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string apparatus_name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string twd97X { get; set; }
        public string twd97Y { get; set; }
        public string wgs84aX { get; set; }
        public string wgs84aY { get; set; }
    }
}