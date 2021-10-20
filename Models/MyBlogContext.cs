using Microsoft.EntityFrameworkCore;

namespace ef_asp{

    public class MyBlogContext : DbContext{

        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            
        }

        

        public DbSet<Article> articles {set;get;}
    }

}