using BlogSpace.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSpace.BL
{
    public class CategoryRule
    {
        public IEnumerable<Category> GetCategory()
        {
            using (var context = new MyDbContext())
            {
                var query = context.Categories;
                return query.ToList();
            }
        }

    }
}
