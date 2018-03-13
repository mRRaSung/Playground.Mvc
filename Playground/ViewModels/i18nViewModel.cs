using System.Web.Mvc;

namespace Playground.ViewModels
{
    public class i18nViewModel
    {
        /// <summary>
        /// Language options
        /// </summary>
        public SelectList Languages { get; set; }
        /// <summary>
        /// Language dislpay text when unselect
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// Selected option
        /// </summary>
        public string Selected { get; set; }
    }
}