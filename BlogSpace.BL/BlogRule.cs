using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlogSpace.Model;
using BlogSpace.DBAccess;
using AutoMapper;


namespace BlogSpace.BL
{
    public class BlogRule
    {
        public IEnumerable<Blog> GetBlog(int pageNo, int pageSize)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Blogs
                    .Include("BlogCategories.Category").AsNoTracking()
                  .OrderByDescending(c => c.PublishedDate);

                //return query.ToList();
                return query.Skip(pageNo * pageSize).Take(pageSize).ToList();
            }
        }

        public Blog GetBlogByIdTitle(int id)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Blogs
                    .Include("BlogCategories.Category").AsNoTracking()
                    .SingleOrDefault(c => c.Id.Equals(id));
                return query;
            }
        }

        public IEnumerable<Blog> GetBlogsByCategory(string category, int pageNo, int pageSize)
        {
            using (var context = new MyDbContext())
            {
                var query = (from p in context.Blogs.Include("BlogCategories.Category").AsNoTracking()
                             join q in context.BlogCategories on p.Id equals q.BlogId
                             join r in context.Categories on q.BlogCategoryId equals r.Id
                             where r.Title.Equals(category)
                             orderby p.PublishedDate descending
                             select p).Include("BlogCategories.Category").AsNoTracking();




                return query.Skip(pageNo * pageSize).Take(pageSize).ToList();
            }
        }

        public IEnumerable<Blog> SearchBlog(string searchText)
        {
            IList<Blog> blogList = new List<Blog>();
            

            using (var context = new MyDbContext())
            {
                var searchParam = new SqlParameter
                {
                    ParameterName = "@searchText",
                    Value = searchText
                };

                var query = context.Database.SqlQuery<BlogViewModel>("usp_SearchBlog @searchText", searchParam).ToList();


                Mapper.CreateMap<BlogViewModel, Blog>();
                Mapper.CreateMap<BlogViewModel, BlogCategory>()
                    .ForMember(bc => bc.Id, bvm => bvm.MapFrom(m => m.BlogCategoryId))
                    .ForMember(bc => bc.BlogId, bvm => bvm.MapFrom(m => m.BlogId))
                    .ForMember(bc => bc.BlogCategoryId, bvm => bvm.MapFrom(m => m.CategoryRefId))
                    .ForMember(bc => bc.CreatedBy, bvm => bvm.MapFrom(m => m.BlogCategoryCreatedBy))
                    .ForMember(bc => bc.CreatedDate, bvm => bvm.MapFrom(m => m.BlogCategoryCreatedDate))
                    .ForMember(bc => bc.ModifiedBy, bvm => bvm.MapFrom(m => m.BlogCategoryModifiedBy))
                    .ForMember(bc => bc.ModifiedDate, bvm => bvm.MapFrom(m => m.BlogCategoryModifiedDate));

                Mapper.CreateMap<BlogViewModel, Category>()
                    .ForMember(bc => bc.Id, bvm => bvm.MapFrom(m => m.CategoryId))
                    .ForMember(bc => bc.Title, bvm => bvm.MapFrom(m => m.CategoryTitle))
                    .ForMember(bc => bc.CreateBy, bvm => bvm.MapFrom(m => m.CategoryCreatedBy))
                    .ForMember(bc => bc.CreatedDate, bvm => bvm.MapFrom(m => m.CategoryCreatedDate))
                    .ForMember(bc => bc.ModifiedBy, bvm => bvm.MapFrom(m => m.CategoryModifiedBy))
                    .ForMember(bc => bc.ModifiedDate, bvm => bvm.MapFrom(m => m.CategoryModifiedDate));


                List<int> ids = new List<int>();
                foreach (BlogViewModel viewModel in query)
                {
                    if (!ids.Contains(viewModel.Id))
                    {
                        ids.Add(viewModel.Id);

                        var filterBlogs = from p in query
                                          where p.Id == viewModel.Id
                                          select p;
                        Blog blog = Mapper.Map<BlogViewModel, Blog>(viewModel);
                        List<BlogCategory> blogCategoryList = new List<BlogCategory>();
                        foreach (BlogViewModel filterblogviewmodel in filterBlogs)
                        {
                            BlogCategory blogCateogry = Mapper.Map<BlogViewModel, BlogCategory>(viewModel);

                            Category cateogry = Mapper.Map<BlogViewModel, Category>(viewModel);
                            if (cateogry.Id != 0)
                            {
                                blogCateogry.Category = cateogry;
                            }
                            if (blogCateogry.Id != 0)
                            {
                                blogCategoryList.Add(blogCateogry);

                            }
                        }
                        blog.BlogCategories = blogCategoryList;
                        blogList.Add(blog);
                    }




                }

                return blogList;
            }
        }


    }
}
