using BlogManagementWeb.Service;
using BlogModels;
using BlogWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class SubscriptionController : Controller
    {
            private readonly ISubscriptionService _SubscriptionService;
            private readonly IBlogService _BlogService;
            public SubscriptionController(ISubscriptionService SubscriptionService, IBlogService blogService)
            {

                _SubscriptionService = SubscriptionService;
                _BlogService = blogService;
            }
            public async Task<IActionResult> Index()
            {

                var subs = await _SubscriptionService.GetSubscriptionsAsync();
                var blogs = _BlogService.GetblogsAsync();
                ViewBag.Blogs = blogs;
                return View(subs);
            }
            public ActionResult Subscribe()
            {
                return View();
            }
        public ActionResult UnSubscribe()
        {
            return View();
        }


       
            public async Task<IActionResult> Subscribe(Subscription subscription)
            {
                if (ModelState.IsValid)
                {
                    var createdSub = await _SubscriptionService.CreateSubscriptionAsync(subscription);
                    TempData["Success"] = "Subscription Successfully";
                    return RedirectToAction(nameof(Index), new { id = createdSub.Id });
                }

                return View(subscription);
            }
            public async Task<IActionResult> UnSubscribe(Subscription subscription)
            {
          //  await _SubscriptionService.DeleteSubscriptionAsync(Subscription);
            TempData["Success"] = "UnSubscription Successfully";
            return View(subscription);
            }
        }
    }
