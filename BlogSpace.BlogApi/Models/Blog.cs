using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSpace.BlogApi.Models
{
    public class Blog
    {
        public Int32 Id;
        public string Title;
        public string Content;
        public string ShortContent;
        public string DetailLinkURL;
        public DateTime PublishedDate;
        public List<BlogCategory> Category;
        public List<string> Authors;
        public List<string> Tags;
    }
}