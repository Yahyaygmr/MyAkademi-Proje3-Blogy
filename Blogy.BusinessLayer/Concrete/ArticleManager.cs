﻿using Blogy.BusinessLayer.Abstaract;
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
            if (entity.Title != null && entity.Description.Length > 50 && entity.CategoryId >= 0)
            {
                _articleDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }

        }

        public void TUpdate(Article entity)
        {

            if (entity.Title != null && entity.Description.Length > 50 && entity.CategoryId >= 0)
            {
                _articleDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }

        }
    }
}
