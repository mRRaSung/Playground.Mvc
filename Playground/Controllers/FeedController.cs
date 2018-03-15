using Playground.Infrastructure.ActionResults;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class FeedController : Controller
    {
        private readonly NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var feed = GetFeedData();

            return new RssActionResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            string hostUrl = string.Format($"{Request.Url.Scheme}://{Request.Url.Authority}");

            //Rss title and link
            var feedResult = new SyndicationFeed("RSS", "Example Description", 
                                           new Uri(string.Concat(hostUrl, "/feed/")));

            List<SyndicationItem> listSynd = new List<SyndicationItem>();
            SyndicationItem syndication;

            //Collect infos
            db.Products.ToList().ForEach(product =>
            {
                syndication = new SyndicationItem(
                    string.Concat(product.Categories.CategoryName, " - ", product.ProductName),
                    string.Format("Quantity per Unit: {0}, Unit Price: {1}", product.QuantityPerUnit, product.UnitPrice),
                    new Uri(string.Concat(hostUrl, "/Products/Details?id=", product.ProductID)),
                    "ID",
                    DateTime.Now);

                listSynd.Add(syndication);
            });

            //Put infos to syndication
            feedResult.Items = listSynd;

            return feedResult;
        }
    }
}