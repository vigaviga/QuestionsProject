using QuestionProject.Models;

namespace QuestionProject.Interfaces
{
    public interface IBlogService
    {
        void CreateBlog(string blogUrl);
        Blog GetBlog(int blogId);

        void DeleteBlog(int blogId);

        void UpdateBlog(Blog blog);
    }
}
