﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFunctions
{
    public class BlogService
    {
        private BloggingContext _db;

        public BlogService(BloggingContext db)
        {
            _db = db;
        }

        public IEnumerable<Blog> SearchBlogs(string term)
        {
            var likeExpression = $"%{term}%";

            return _db.Blogs.FromSql("SELECT * FROM dbo.Blogs WHERE Url LIKE {0}", likeExpression);
        }
    }
}
