using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;
using QuestionProject.Interfaces;
using QuestionProject.Models;

namespace QuestionProject.Services
{
    public class BlogService : IBlogService
    {
        private BloggingContext db;

        public BlogService() 
        {
            db = new BloggingContext();
        }

        //Question 4: How would change the definition of below method to make it follow best practices?
        public async void CreateBlog(string blogUrl)
        //Answer 4: public async Task CreateBlog(string blogUrl)
        {
            var blog = new Blog() { Url = blogUrl };
            db.Add(blog);
            await db.SaveChangesAsync();
        }

        public Blog GetBlog(int blogId)
        {
            //Question 5: How would you improve performance of this LINQ query?
            var blog = db.Blogs
                .Where(b => b.BlogId == blogId)
                .FirstOrDefault();

            //Answer 5:
            //var blog = db.Blogs
            //    .FirstOrDefault(b => b.BlogId == blogId);


            return blog;
        }

        public void DeleteBlog(int blogId)
        {
            var blog = db.Blogs.FirstOrDefault(b => b.BlogId == blogId);
            db.Remove(blog);
            db.SaveChanges();
        }
        //Question 6: Whats wrong in this code?
        public void UpdateBlog(Blog blog)
        {
            //Such blog may not exist. So, we should check if such blog exists at first.
            //if(db.Blogs.FirstOrDefault(b => b.BlogId == blogId) == null)
            //{
            //  notify that such blog doesn't exist
            //}
            db.Update(blog);
            db.SaveChanges();
        }

        //Question 10: How would you implement the algorithm of finding the most viewed post?
        private void MostViewedPost(Blog blog)
        {
            //Answer 10:
            //Complexity is O(n)
            //int maxViewPostId = -1;
            //int maxViewCount = -1;

            //foreach(var p in blog.Posts)
            //{
            //    if (p.ViewCount > maxViewCount)
            //    {
            //        maxViewPostId = p.PostId;
            //    }
            //}
        }
        //Question 7: Can this method throw an exception? If yes - how would you handle it?
        private static bool IsDefaultValue(PropertyInfo srcProperty, object src)
        {
            var type = srcProperty.GetValue(src, null).GetType();

            if (typeof(DateTime) == type)
            {
                return (DateTime)srcProperty.GetValue(src, null) == DateTime.MinValue;
            }
            if (typeof(string) == type)
            {
                return (string)srcProperty.GetValue(src, null) == string.Empty;
            }
            return false;
        }
        //Answer 7: Yes - srcProperty.GetValue(src, null) can return null. 
        //Solution would be to replase line 63 with
        //if (srcProperty.GetValue(src, null) == null)
        //    return true;
        //var type = srcProperty.GetValue(src, null).GetType();

        //Question 11: How can you modify this method to enhance its performance?

        private void CalculateTarget(Blog target, List<Blog> blogs)
        {
            //Answer 11: Move calculation of b outside of loop. Explanation: Its value does not change after each iteration.
            //var b = target.Posts.FirstOrDefault(a => a.IsNewPost.Equals(true));
            foreach (var blog in blogs)
            {
                var a = blog.Posts.FirstOrDefault(a => a.IsNewPost.Equals(true));
                var b = target.Posts.FirstOrDefault(a => a.IsNewPost.Equals(true));

                if (a != null && b != null)
                {
                    //some work
                }
            }
        }
    }
}
 