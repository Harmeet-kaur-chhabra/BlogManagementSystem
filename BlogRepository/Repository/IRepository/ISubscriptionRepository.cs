using BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.IRepository
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        void Update(Subscription sub);
    }
}
