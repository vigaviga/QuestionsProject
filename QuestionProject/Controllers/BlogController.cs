using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionProject.Services;
using System;

namespace QuestionProject.Controllers
{
    public class BlogController : Controller
    {
        private BlogService blogService;
        public BlogController()
        {
            //Question 1: How would you change this code to make more loose coupled code?
            blogService = new BlogService();
        }

        //Question 2: How would you change the controllers so that internal server errors are handled in one place?
        //Question 3: How would you change the endpoints and their return types so that they become more scalable and responsive in case the number of requests 50 folds?
        [HttpGet]
        public IActionResult Get(int blogId)
        {
            //Question 8: What would you change in response of this code?
            //Answer 8: Blog service can return null. So, I will add a return statement in case blog equals null. 
            // if (blog == null) return NotFound(blogId);
            try
            {
                var blog = blogService.GetBlog(blogId);
                return Ok(blog);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] string blogUrl)
        {
            try
            {
                //Answer 9:
                //if(ModelState.IsValid)
                //{
                //    code comes here
                //}

                blogService.CreateBlog(blogUrl);
                return Ok();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            try
            {
                blogService.DeleteBlog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}

//Answer 1: I would use DI
//Answer 2: A global exception handler should be added by creating an error handling middleware. 
//And it should be registered in the beginning of ASP .Net core middleware.
//Answer 3: I would make all endpoint asyncrhonous and all methods in service class also asynchrnous.

//After changes endpoints woud look like this
//public class BlogController : Controller
//{
//    private IBlogService _blogService;
//    public BlogController(IBlogService blogService)
//    {
//        _blogService = blogService;
//    }

//    [HttpGet]
//    public async Task<IActionResult> Get(int blogId)
//    {
//        var blog = _blogService.GetBlog(blogId);
//        return Ok(blog);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Post([FromBody] string blogUrl)
//    {
//        _blogService.CreateBlog(blogUrl);
//        return Ok();
//    }

//    [HttpDelete("id/{id}")]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    public async Task<IActionResult> Delete(int id)
//    {
//        _blogService.DeleteBlog(id);
//        return Ok();
//    }
//}

