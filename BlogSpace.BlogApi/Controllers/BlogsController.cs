using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using BlogSpace.BL;
using BlogSpace.DBAccess;
using System.Configuration;


namespace BlogSpace.BlogApi.Controllers
{
    /// <summary>
    /// Blog API
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlogsController : ApiController
    {
        IEnumerable<DBAccess.Blog> blogItems = new List<DBAccess.Blog>();
        DBAccess.Blog blogItem;
        BlogRule blogRule = null;
        int pageSize = 0;

        public BlogsController()
        {
            blogRule = new BlogRule();
            pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        }

       
        /// <summary>
        /// GET: /Blogs/
        /// </summary>
        /// <returns>returns all the blog posts</returns>
        public HttpResponseMessage Get()
        {
            this.blogItems = blogRule.GetBlog(0, pageSize);
            var response = this.Request.CreateResponse(HttpStatusCode.OK, this.blogItems);
            return response;
        }

        /// <summary>
        /// GET: /Blogs/
        /// </summary>
        /// <returns>returns all the blog posts and use paging</returns>
        public HttpResponseMessage Get(int pageIndex)
        {

            this.blogItems = blogRule.GetBlog(pageIndex, pageSize);
            var response = this.Request.CreateResponse(HttpStatusCode.OK, this.blogItems);
            return response;
        }


        /// <summary>
        /// GET: categories/{cateogry}/Blogs/ 
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="pageIndex">pageindex</param>
        /// <returns>returns all the blogs by category with paging</returns>
        [ActionName("GetBlogsByCategory")]
        public HttpResponseMessage Get(string category, int pageIndex)
        {
            string encodedCategory = System.Web.HttpContext.Current.Server.HtmlEncode(category);

            blogItems = blogRule.GetBlogsByCategory(category, pageIndex, pageSize);

            var response = this.Request.CreateResponse(HttpStatusCode.OK, blogItems);
            return response;
        }

        
        /// <summary>
        /// GET: /Blogs/id/title 
        /// </summary>
        /// <param name="id">id of the blog post</param>
        /// <param name="title">title of the blog post</param>
        /// <returns>returns a single blog post for the id passed</returns>
        [ActionName("GetBlogByIdTitle")]
        public HttpResponseMessage Get(int id, string title)
        {
            string encodedTitle = System.Web.HttpContext.Current.Server.HtmlEncode(title);

            blogItem = blogRule.GetBlogByIdTitle(id);

            var response = this.Request.CreateResponse(HttpStatusCode.OK, blogItem);
            return response;
        }


        //// GET: /category/blog/search
        //[ActionName("SearchBlogsInCategory")]
        //[HttpGet]
        //public HttpResponseMessage Get(string category, string search)
        //{
        //    string encodedCategory = System.Web.HttpContext.Current.Server.HtmlEncode(category);
        //    string encodedSearch = System.Web.HttpContext.Current.Server.HtmlEncode(search);

        //    //blogItems = (from blog in this.blogItems
        //    //                       where blog.BlogCategories.Contains(.Title.Equals(encodedCategory) && blog.Title.StartsWith(encodedSearch)
        //    //                       select blog).ToList();

        //    var response = this.Request.CreateResponse(HttpStatusCode.OK, blogItem);
        //    return response;
        //}

        /// <summary>
        /// GET: /category/blog/search 
        /// </summary>
        /// <param name="search">search text</param>
        /// <returns>returns blog posts based on search text</returns>
        [ActionName("SearchBlogs")]
        [HttpGet]
        public HttpResponseMessage Search(string search)
        {
            string encodedSearch = System.Web.HttpContext.Current.Server.HtmlEncode(search);

            blogItems = blogRule.SearchBlog(search);

            var response = this.Request.CreateResponse(HttpStatusCode.OK, blogItems);
            return response;
        }
    }
}