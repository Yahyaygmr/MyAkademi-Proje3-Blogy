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
            var values = _context.Articles
                .Where(x => x.AppUserId == id)
                .OrderByDescending(x => x.ArticleId)
                .ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
        {
            return _context.Articles
                 .Include(x => x.AppUser)
                 .OrderByDescending(x=>x.ArticleId)
                 .ToList();
        }

        public List<Article> GetArticleWithWriterAndCategory()
        {
            return _context.Articles
                .Include(x => x.AppUser)
                .Include(x => x.Category)
                .ToList();
        }

        public List<Article> GetLastNArticle(int count)
        {
            var values = _context.Articles
               .OrderByDescending(x => x.ArticleId)
               .Take(count)
               .ToList();
            return values;
        }

        public AppUser GetWriterInfoByArticleWriter(int id)
		{
			return _context.Articles
                .Where(x => x.ArticleId == id)
                .Select(y => y.AppUser)
                .FirstOrDefault();
		}
	}
}
