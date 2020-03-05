using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace WebServis.Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Feed1" in both code and config file together.
    public class Feed1 : IFeed1
    {
        // TODO: yeni seyler var yapilacak
        // TODO: yapilacaklar

        public SyndicationFeedFormatter CreateFeed()
        {
            // Create a new Syndication Feed.
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "A WCF Syndication Feed", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            // Create a new Syndication Item.
            SyndicationItem item = new SyndicationItem("An item", "Item content", null);
            items.Add(item);
            feed.Items = items;

            // Return ATOM or RSS based on query string
            // rss -> http://localhost:8733/Design_Time_Addresses/WebServis.Host/Feed1/
            // atom -> http://localhost:8733/Design_Time_Addresses/WebServis.Host/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }
    }
}
