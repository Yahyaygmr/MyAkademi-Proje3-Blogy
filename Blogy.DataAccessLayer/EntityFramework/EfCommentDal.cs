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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly BlogyContext _context;
        public EfCommentDal(BlogyContext context) : base(context)
        {
            _context = context;
        }
        public List<Comment> GetCommentsByArticleId(int id)
        {
            var values = _context.Comments.Where(x => x.ArticleId == id && x.Status == true).ToList();
            return values;
        }

        public List<Comment> GetCommentsEithArticle()
        {
            return _context.Comments.Include(x => x.Article).ToList();
        }
    }
}
