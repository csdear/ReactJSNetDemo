using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactJSNet.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactJSNet.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;
        
        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Benson Hedges",
                    Text = "Where are my smokes"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Sally Forth",
                    Text = "Bottlecaps"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Ichabod Axelrod",
                    Text = "Cataclysmic Convertors"
                },
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }
		
		[Route("comments/new")]
		[HttpPost]
		public ActionResult AddComment(CommentModel comment)
		{
			// Create a fake ID for this comment
			comment.Id = _comments.Count + 1;
			_comments.Add(comment);
			return Content("Success :)");
		}


    }
}
