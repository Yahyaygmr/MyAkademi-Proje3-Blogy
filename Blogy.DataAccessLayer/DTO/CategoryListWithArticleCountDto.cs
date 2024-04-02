using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.DTO
{
    public class CategoryListWithArticleCountDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ArticleCount { get; set; }
    }
}
