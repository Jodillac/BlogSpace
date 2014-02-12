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

namespace BlogSpace.BlogApi.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {

        IEnumerable<DBAccess.Category> blogCategories = new List<DBAccess.Category>();
        DBAccess.Category categoryItem;
        CategoryRule categoryRule = null;

        public CategoriesController()
        {
            categoryRule = new CategoryRule();
        }

        
        
        /// <summary>
        /// GET: /categories/
        /// </summary>
        /// <returns>returns categories</returns>
        public HttpResponseMessage Get()
        {
            this.blogCategories = categoryRule.GetCategory();
            var response = this.Request.CreateResponse(System.Net.HttpStatusCode.OK, this.blogCategories);
            return response;
        }
    }
}