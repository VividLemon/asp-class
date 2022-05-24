using System.Collections.Generic;
using Lab_06.Models;
namespace Lab_06.Models.ViewModels
{
    public class CommentIndexViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}