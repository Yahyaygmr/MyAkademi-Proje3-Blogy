using Blogy.BusinessLayer.Abstaract;
using Blogy.DataAccessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

		public ContactUsManager(IContactUsDal contactUsDal)
		{
			_contactUsDal = contactUsDal;
		}

		public DbSet<ContactUs> GetTContext()
        {
           return _contactUsDal.GetTContext();
        }

        public void TDelete(int id)
        {
            _contactUsDal.Delete(id);
        }

        public ContactUs TGetById(int id)
        {
           return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetListAll()
        {
           return _contactUsDal.GetListAll();
        }

        public void TInsert(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void TUpdate(ContactUs entity)
        {
            _contactUsDal.Update(entity);
        }
    }
}
