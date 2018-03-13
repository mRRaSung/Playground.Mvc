using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.ViewModels
{
    public class i18nViewModel
    {
        public SelectList Languages { get; set; }

        public string Display { get; set; }

        public string Selected { get; set; }
    }
}