using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSpace.Model
{
    public class BlogViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Content { get; set; } // Content
        public string ShortContent { get; set; } // ShortContent
        public string DetailLinkUrl { get; set; } // DetailLinkURL
        public DateTime PublishedDate { get; set; } // PublishedDate
        public DateTime CreatedDate { get; set; } // CreatedDate
        public int CreatedBy { get; set; } // CreatedBy
        public DateTime ModifiedDate { get; set; } // ModifiedDate
        public int ModifiedBy { get; set; } // ModifiedBy

        public int? BlogCategoryId { get; set; } // Id (Primary key)
        public int? BlogId { get; set; } // BlogId
        public int? CategoryRefId { get; set; } // BlogCategoryId
        public int? BlogCategoryCreatedBy { get; set; } // CreatedBy
        public DateTime? BlogCategoryCreatedDate { get; set; } // CreatedDate
        public int? BlogCategoryModifiedBy { get; set; } // ModifiedBy
        public DateTime? BlogCategoryModifiedDate { get; set; } // ModifiedDate

        public int? CategoryId { get; set; } // Id (Primary key)
        public string CategoryTitle { get; set; } // Title
        public DateTime? CategoryCreatedDate { get; set; } // CreatedDate
        public int? CategoryCreatedBy { get; set; } // CreateBy
        public DateTime? CategoryModifiedDate { get; set; } // ModifiedDate
        public int? CategoryModifiedBy { get; set; } // ModifiedBy

    }
}