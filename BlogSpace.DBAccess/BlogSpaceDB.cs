

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "BlogSpace.DBAccess\App.config"
//     Connection String Name: "MyDbContext"
//     Connection String:      "data source=NDI-LAP-156;initial catalog=BlogSpace;integrated security=True;Application Name=MyApp"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace BlogSpace.DBAccess
{
    // ************************************************************************
    // Unit of work
    public interface IMyDbContext : IDisposable
    {
        IDbSet<Blog> Blogs { get; set; } // Blog
        IDbSet<BlogCategory> BlogCategories { get; set; } // BlogCategory
        IDbSet<BlogTag> BlogTags { get; set; } // BlogTag
        IDbSet<Category> Categories { get; set; } // Category
        IDbSet<Tag> Tags { get; set; } // Tag

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public class MyDbContext : DbContext, IMyDbContext
    {
        public IDbSet<Blog> Blogs { get; set; } // Blog
        public IDbSet<BlogCategory> BlogCategories { get; set; } // BlogCategory
        public IDbSet<BlogTag> BlogTags { get; set; } // BlogTag
        public IDbSet<Category> Categories { get; set; } // Category
        public IDbSet<Tag> Tags { get; set; } // Tag

        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=MyDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false; 
        }

        public MyDbContext(string connectionString) : base(connectionString)
        {
        }

        public MyDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new BlogCategoryConfiguration());
            modelBuilder.Configurations.Add(new BlogTagConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new BlogConfiguration(schema));
            modelBuilder.Configurations.Add(new BlogCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new BlogTagConfiguration(schema));
            modelBuilder.Configurations.Add(new CategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new TagConfiguration(schema));
            return modelBuilder;
        }
    }

    // ************************************************************************
    // POCO classes

    // Blog
    public class Blog
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

        // Reverse navigation
        public virtual ICollection<BlogCategory> BlogCategories { get; set; } // BlogCategory.FK_BlogCategory_Blog
        public virtual ICollection<BlogTag> BlogTags { get; set; } // BlogTag.FK_BlogTag_Blog

        public Blog()
        {
            BlogCategories = new List<BlogCategory>();
            BlogTags = new List<BlogTag>();
        }
    }

    // BlogCategory
    public class BlogCategory
    {
        public int Id { get; set; } // Id (Primary key)
        public int BlogId { get; set; } // BlogId
        public int BlogCategoryId { get; set; } // BlogCategoryId
        public int CreatedBy { get; set; } // CreatedBy
        public DateTime CreatedDate { get; set; } // CreatedDate
        public int ModifiedBy { get; set; } // ModifiedBy
        public DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys
        public virtual Blog Blog { get; set; } //  FK_BlogCategory_Blog
        public virtual Category Category { get; set; } //  FK_BlogCategory_Category
    }

    // BlogTag
    public class BlogTag
    {
        public int Id { get; set; } // Id (Primary key)
        public int TagId { get; set; } // TagId
        public DateTime CreatedDate { get; set; } // CreatedDate
        public int CreatedBy { get; set; } // CreatedBy
        public DateTime ModifiedDate { get; set; } // ModifiedDate
        public int ModifiedBy { get; set; } // ModifiedBy

        // Foreign keys
        public virtual Blog Blog { get; set; } //  FK_BlogTag_Blog
    }

    // Category
    public class Category
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public DateTime? CreatedDate { get; set; } // CreatedDate
        public int? CreateBy { get; set; } // CreateBy
        public DateTime? ModifiedDate { get; set; } // ModifiedDate
        public int? ModifiedBy { get; set; } // ModifiedBy

        // Reverse navigation
        public virtual ICollection<BlogCategory> BlogCategories { get; set; } // BlogCategory.FK_BlogCategory_Category

        public Category()
        {
            BlogCategories = new List<BlogCategory>();
        }
    }

    // Tag
    public class Tag
    {
        public int Id { get; set; } // Id (Primary key)
        public string Tag_ { get; set; } // Tag
        public int? CreatedBy { get; set; } // CreatedBy
        public DateTime? CreatedDate { get; set; } // CreatedDate
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? ModifiedDate { get; set; } // ModifiedDate
    }


    // ************************************************************************
    // POCO Configuration

    // Blog
    internal class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Blog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(250);
            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.ShortContent).HasColumnName("ShortContent").IsOptional().HasMaxLength(2000);
            Property(x => x.DetailLinkUrl).HasColumnName("DetailLinkURL").IsOptional().HasMaxLength(200);
            Property(x => x.PublishedDate).HasColumnName("PublishedDate").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsRequired();
        }
    }

    // BlogCategory
    internal class BlogCategoryConfiguration : EntityTypeConfiguration<BlogCategory>
    {
        public BlogCategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".BlogCategory");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BlogId).HasColumnName("BlogId").IsRequired();
            Property(x => x.BlogCategoryId).HasColumnName("BlogCategoryId").IsRequired();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();

            // Foreign keys
            HasRequired(a => a.Blog).WithMany(b => b.BlogCategories).HasForeignKey(c => c.BlogId); // FK_BlogCategory_Blog
            HasRequired(a => a.Category).WithMany(b => b.BlogCategories).HasForeignKey(c => c.BlogCategoryId); // FK_BlogCategory_Category
        }
    }

    // BlogTag
    internal class BlogTagConfiguration : EntityTypeConfiguration<BlogTag>
    {
        public BlogTagConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".BlogTag");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TagId).HasColumnName("TagId").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsRequired();

            // Foreign keys
            HasRequired(a => a.Blog).WithMany(b => b.BlogTags).HasForeignKey(c => c.TagId); // FK_BlogTag_Blog
        }
    }

    // Category
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Category");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(25);
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreateBy).HasColumnName("CreateBy").IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
        }
    }

    // Tag
    internal class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Tag");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Tag_).HasColumnName("Tag").IsOptional().HasMaxLength(30);
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
        }
    }

}

