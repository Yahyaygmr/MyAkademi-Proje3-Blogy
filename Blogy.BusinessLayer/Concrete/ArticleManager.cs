using Blogy.BusinessLayer.Abstaract;
using Blogy.DataAccessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public AppUser TGetWriterInfoByArticleWriter(int id)
        {
            return _articleDal.GetWriterInfoByArticleWriter(id);
        }

        public void TDelete(int id)
        {
            if (id != 0)
            {
                _articleDal.Delete(id);
            }
            else
            {
                //Hata Mesajı
            }

        }

        public List<Article> TGetArticleWithWriter()
        {
            return _articleDal.GetArticleWithWriter();
        }

        public Article TGetById(int id)
        {
            //Eğer Id değerine göre veri çekme yetkisi varsa
            return _articleDal.GetById(id);
        }

        public List<Article> TGetListAll()
        {
            return _articleDal.GetListAll();
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);

            //hata mesajı


        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public List<Article> TGetArticlesByArticleByWriter(int id)
        {
            return _articleDal.GetArticlesByArticleByWriter(id);
        }
    }
}
