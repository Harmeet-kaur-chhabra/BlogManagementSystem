﻿using BlogManagementWeb.Service;
using BlogUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class AdminController : Controller
        {
            private readonly IAdminService _adminService;
        
            public AdminController(IAdminService adminService)
            {
                _adminService = adminService;
            }

            public async Task<IActionResult> Index()
            {
                var posts = await _adminService.GetUsersAsync();
                return View(posts);
            }
            [HttpPost]
            public async Task<IActionResult> ApproveBlog(int id)
            {
                try
                {
                    await _adminService.ApproveBlog(id);
                    TempData["Success"] = "Approved";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View("Index");
                }
            }

            [HttpPost]
            public async Task<IActionResult> RejectBlog(int id)
            {
                try
                {
                    await _adminService.RejectBlog(id);
                    TempData["Success"] = "Rejected Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View("Index");
                }
            }
        }
}

