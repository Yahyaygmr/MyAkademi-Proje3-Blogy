using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.Context;
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
    public class EfWriterMessageDal : GenericRepository<WriterMessage>, IWriterMessageDal
    {
        private readonly BlogyContext _context;
        public EfWriterMessageDal(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<WriterMessage> GetWriterMessagesByUser(AppUser user)
        {
            return _context.WriterMessages
                .Where(x => x.RecieverMail == user.Email)
                .Include(x => x.AppUser)
                .ToList();
        }
        public WriterMessage GetWriterMessagesByIdWithUser(int id)
        {
            return _context.WriterMessages
                .Include(x => x.AppUser)
                .Where(x => x.WriterMessageId == id)
                .FirstOrDefault();

        }
    }
}
