using BlogData.Repository.IRepository;
using BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository
{
    public class BlogsRepository : Repository<Blog>, IBlogsRepository
    {
        private readonly ApplicationDbContext _db;
        public BlogsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Blog blog)
        {

            _db.Blogs.Update(blog);


        }
    }
}
