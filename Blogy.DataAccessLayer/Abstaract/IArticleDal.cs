using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstaract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticleWithWriter();
        AppUser GetWriterInfoByArticleWriter(int id);
        List<Article> GetArticlesByArticleByWriter(int id);
    }
}
