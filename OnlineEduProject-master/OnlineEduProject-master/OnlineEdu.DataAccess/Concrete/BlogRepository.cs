﻿using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly OnlineEduContext _onlineEduContext;
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
            _onlineEduContext = _context;
        }

        public List<Blog> Get4LastBlogsWithCategories()
        {
            return _context.Blogs.Include(x=>x.BlogCategory).OrderByDescending(x=>x.BlogId).Take(4).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).ToList(); ;
        }

        public List<Blog> GetBlogsWithCategoriesByWriterId(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToList();
        }
    }
}
