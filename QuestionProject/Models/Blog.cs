using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuestionProject.Models
{
    //Question 9: When creating a model you want to ensure a Url string is provided. How would you achieve that?
    public class Blog
    {
        public int BlogId { get; set; }
        //Answer 9: Add required attribute. And check if model is valid in controller endpoints. 
        //[Required]
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}
