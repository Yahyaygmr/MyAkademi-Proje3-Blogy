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

		public List<Article> GetArticleWithWriter()
		{
			return _context.Articles
				.Include(x => x.Writer)
				.ToList();
		}

        public Writer GetWriterInfoByArticleWriter(int id)
        {
			return _context.Articles.Where(x => x.ArticleId == id).Select(y => y.Writer).FirstOrDefault();
        }
    }
}
