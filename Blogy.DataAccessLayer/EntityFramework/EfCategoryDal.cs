using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.DTO;
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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BlogyContext _context;
        public EfCategoryDal(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }

        public List<CategoryListWithArticleCountDto> GetCategoryWithArticleCount()
        {
            var categories = _context.Categories
                .Include(x => x.Articles);
            return categories.Select(x => new CategoryListWithArticleCountDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                ArticleCount = _context.Articles.Count(y => y.CategoryId == x.CategoryId)
            }).ToList();
        }
    }
}
