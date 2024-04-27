using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstaract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TGetArticleWithWriter();
        List<Article> TGetArticleWithWriterAndCategory();
        AppUser TGetWriterInfoByArticleWriter(int id);
        List<Article> TGetArticlesByArticleByWriter(int id);
        List<Article> TGetLastNArticle(int count);


    }
}
