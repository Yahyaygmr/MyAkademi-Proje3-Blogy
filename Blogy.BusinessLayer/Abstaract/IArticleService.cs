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
        Writer TGetWriterInfoByArticleWriter(int id);
        List<Article> TGetArticlesByArticleByWriter(int id);


    }
}
