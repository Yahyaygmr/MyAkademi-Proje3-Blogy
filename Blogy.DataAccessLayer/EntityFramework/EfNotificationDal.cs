using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly BlogyContext _context;
        public EfNotificationDal(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<Notification> GetLast3Notifications()
        {
            return _context.Notifications
                .OrderByDescending(x=> x.NotificationId)
                .Take(3)
                .ToList();
        }
    }
}
