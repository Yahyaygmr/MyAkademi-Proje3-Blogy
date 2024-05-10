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
    public class WriterMessageManager : IWriterMessageService
    {
        private readonly IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        public DbSet<WriterMessage> GetTContext()
        {
            return _writerMessageDal.GetTContext();
        }

        public void TDelete(int id)
        {
            _writerMessageDal.Delete(id);
        }

        public WriterMessage TGetById(int id)
        {
            return _writerMessageDal.GetById(id);
        }

        public List<WriterMessage> TGetListAll()
        {
            return _writerMessageDal.GetListAll();
        }

        public List<WriterMessage> TGetWriterMessagesByUser(AppUser user)
        {
            return _writerMessageDal.GetWriterMessagesByUser((AppUser)user);
        }

        public void TInsert(WriterMessage entity)
        {
            _writerMessageDal.Insert(entity);
        }

        public void TUpdate(WriterMessage entity)
        {
            _writerMessageDal.Update(entity);
        }
        public WriterMessage TGetWriterMessagesByIdWithUser(int id)
        {
            return _writerMessageDal.GetWriterMessagesByIdWithUser(id);
        }
    }
}
