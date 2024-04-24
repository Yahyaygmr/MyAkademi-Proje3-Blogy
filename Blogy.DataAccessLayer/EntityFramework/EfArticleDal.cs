using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly BlogyContext _context;
        public EfArticleDal(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<Article> GetArticlesByArticleByWriter(int id)
        {
            var values = _context.Articles.Where(x => x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
        {
            throw new NotImplementedException();
        }
    }
}
