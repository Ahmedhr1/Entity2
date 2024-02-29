using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Threading.Channels;

public class BloggingContext : DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");

    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>

        options.UseSqlite($"Data Source ={DbPath}");

}


public class Program
{
    


        public static void Main()
        {

          BloggingContext db = new();

          

          db.users.Add(new User { Name = "Ahmed" });
          db.SaveChanges();

          db.categories.Add(new Category { name = "Crime" });


          db.Blogs.Add(new Blog { name = "Bloggers1" });
          db.Blogs.Add(new Blog { name = "Bloggers2" });
          db.SaveChanges();

          Blog blog = db.Blogs.Where(b => b.name == "Bloggers1").First();

          db.users.First().Articles.Add(new Article { title = "Mord i Malmö", Blog = blog });

          db.categories.First().Articles.Add(db.users.First().Articles.Where(a => a.title == "Mord i Malmö").First());
          db.SaveChanges();

          //Console.WriteLine(db.categories.First().Articles.First().User.Articles.First().Blog.Articles.First().title);
          Console.WriteLine(db.Articles.First().title);

    }




}






