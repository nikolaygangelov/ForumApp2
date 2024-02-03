using ForumApp2.Core.Contracts;
using ForumApp2.Core.Models;
using ForumApp2.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp2.Controllers
{
    /// <summary>
	/// PostController inherits Controller class 
	/// gives you access to Request, Response, ViewBag, ViewData, View, etc.
	/// </summary>
    public class PostController : Controller
    {
        private readonly IPostService postService;

        /// <summary>
        /// using dependancy (interface) injection through constructor
        /// gives access to PostService class which implements this interface
        /// </summary>
        /// <param name="postService"></param>
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        /// <summary>
        /// using asynchronous programming
        /// action method mapped to Home/Index
        /// return View with all current posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await postService.GetAllPostsAsync();

            return View(model);
        }

        /// <summary>
        /// passes a view model with default values 
        /// step 1 - just loading page with input form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostModel();

            return View(model);
        }


        /// <summary>
        /// adding post
        /// step 2 - saving page with added posts
        /// </summary>
        /// <param name="model"></param>
        /// <returns>added posts</returns>
        [HttpPost] //sending data to server; action will be invoked on a "POST" request to "/Post/Add or just /Add"
        public async Task<IActionResult> Add(PostModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await postService.AddPostAsync(model);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// editing a post by id
        /// step 1 - finding the post to edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>found post to the View</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await postService.GetPostByIdAsync(id);

            return View(entity);
        }


        /// <summary>
        /// editing a post by id
        /// step 2 - updating the found post
        /// using one validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns>all post including edited ones</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(PostModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await postService.UpdatePostAsync(model);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// finding and removing posts
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all post excluding deleted ones</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await postService.DeletePostAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
