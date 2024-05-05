using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        public DbSet<Notification> GetTContext()
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
