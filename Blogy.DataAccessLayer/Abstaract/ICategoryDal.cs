using Blogy.DataAccessLayer.DTO;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstaract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int GetCategoryCount();
        List<CategoryListWithArticleCountDto> GetCategoryWithArticleCount();
    }
}
