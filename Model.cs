using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    public int? userID { get; set; }
    public string? Name { get; set; }
    public string? password { get; set; }
    public List<Article>? Articles { get; } = new();


    //public void AddArticle(Article article)
    //{
    //    articles.Add(article);
    //    article.User = this;
    //}

   

}
public class Article
{
    public int? ArticleID { get; set; }
    public string? title { get; set; }
    public List<Category>? categories { get; } = new();
    public Blog? Blog { get; set; }
    public User? User { get; set; }


}

public class Category
{
    public int? categoryID { get; set; }
    public string? name { get; set; }
    public List<Article>? Articles { get; } = new();

    
}
public class Blog
{
    public int? BlogID { get; set; }
    public string? name { get; set; }
    public List<Article>? Articles { get; } = new();


}