using Playground.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class i18nController : Controller
    {
        //all http method, i18n
        public ActionResult Index(string selectedLang = "zh-TW")
        {
            i18nViewModel model = new i18nViewModel();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLang);

            //Language options
            SelectList items = new SelectList(
                items: new List<SelectListItem>{
                    new SelectListItem{ Text = "繁體中文", Value = "zh-TW" },
                    new SelectListItem{ Text = "English", Value = "en-US" },
                    new SelectListItem{ Text = "日本語", Value = "ja-JP"}
                },
                dataTextField: "Text",
                dataValueField: "Value"
            );
            model.Languages = items;

            //Selected option
            model.Selected = selectedLang;

            //Please Select at first option
            model.Display = Resources.ChooseLang;

            return View(model);
        }
    }
}