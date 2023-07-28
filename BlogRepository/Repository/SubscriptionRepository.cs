using BlogData.Repository.IRepository;
using BlogModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private readonly ApplicationDbContext _db;
        public SubscriptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Subscription sub)
        {

       //     _db.Subscriptions.Update(sub);


        }
    }
}
