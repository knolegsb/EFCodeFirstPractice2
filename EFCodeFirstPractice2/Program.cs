using EFCodeFirstPractice2.Contexts;
using EFCodeFirstPractice2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new SchoolContext())
            //{
            //    Student student = new Student()
            //    {
            //        StudentName = "New Student"
            //    };

            //    context.Students.Add(student);
            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            //    {
            //        Console.WriteLine(ex.InnerException.Message);
            //    }
            //}

            using (var db = new BloggingContext())
            {
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var Blog = new Blog { Name = name };

                db.Blogs.Add(Blog);
                db.SaveChanges();

                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Preas any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
