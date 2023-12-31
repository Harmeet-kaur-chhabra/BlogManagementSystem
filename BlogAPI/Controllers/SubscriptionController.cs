﻿using AutoMapper;
using BlogData.Repository.IRepository;
using BlogData;
using Microsoft.AspNetCore.Mvc;
using BlogData.Repository;
using BlogModels;
using BlogModels.Dto;
using Microsoft.AspNetCore.Authorization;

namespace BlogAPI.Controllers
{
    [Route("/api/Subscription")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subRepo;
        private readonly IBlogsRepository _blogRepo;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionRepository subRepo, IBlogsRepository blogRepo, ApplicationDbContext context, IMapper mapper)
        {
            _subRepo = subRepo;
            _blogRepo = blogRepo;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubscriptions()
        {
            IEnumerable<Subscription> sub = _subRepo.GetAll().ToList();
            return Ok(sub);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var sub = _subRepo.Get(u => u.Id == id);
            if (sub == null)
            {
                return NotFound();
            }
            return Ok(sub);
        }


        [HttpPost]

        public IActionResult CreateSubscription([FromBody] SubscriptionDto subscription)
        {
            if (subscription == null)
            {
                return BadRequest();
            }
                var blog = _context.Blogs.FirstOrDefault(u => u.Id == subscription.BlogId);
            if (blog == null)
                return NotFound();

            if (blog.SubscriptionsAllowed <= 0)
                return BadRequest("No available subscriptions for this blog.");

            var subscriptions = new Subscription
            {
                BlogId = subscription.BlogId,
             

            };
            Subscription result = _mapper.Map<Subscription>(subscriptions);

            _subRepo.Add(result);
            blog.SubscriptionsAllowed--;
            _blogRepo.Update(blog);
            Subscription Sub = _mapper.Map<Subscription>(subscription);
            _subRepo.Save();
            return Ok(result);
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscription(int subscriptionId)
        {
            var subscription = _subRepo.Get(u => u.Id == subscriptionId);
            if (subscription == null)
                return NotFound();

            _subRepo.Remove(subscription);

                var blog = _context.Blogs.FirstOrDefault(u => u.Id == subscription.BlogId);
            if (blog != null)
            {
                blog.SubscriptionsAllowed++;
                _blogRepo.Update(blog);
                _subRepo.Save();
            }

            return Ok();
        }
    }
}
