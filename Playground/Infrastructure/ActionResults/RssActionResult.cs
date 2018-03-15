using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace Playground.Infrastructure.ActionResults
{
    public class RssActionResult : ActionResult
    {
        /// <summary>
        /// Rss 資訊聚合
        /// </summary>
        private SyndicationFeed Feed;

        public RssActionResult(SyndicationFeed feed)
        {
            this.Feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //Set content type
            context.HttpContext.Response.ContentType = "application/rss+xml";

            //Rss Formatter
            var formatter = new Rss20FeedFormatter(Feed);

            //Output by Rss formatter
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }

        }
    }
}