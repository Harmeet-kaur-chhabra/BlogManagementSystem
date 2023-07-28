using BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.IRepository
{
    public interface IBlogsRepository : IRepository<Blog>
    {
        void Update(Blog blog);
    }
}
