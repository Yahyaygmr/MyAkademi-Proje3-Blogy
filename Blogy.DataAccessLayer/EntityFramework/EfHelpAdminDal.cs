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
    public class EfHelpAdminDal : GenericRepository<HelpAdmin>, IHelpAdminDal
    {
        private readonly BlogyContext _context;
        public EfHelpAdminDal(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<HelpAdmin> GetHelpAdminWithAppUser()
        {
            return _context.HelpAdmins.Include(x => x.AppUser).ToList();
        }

        public HelpAdmin GetHelpAdminWithAppUserById(int id)
        {
            return _context.HelpAdmins
                .Include(x => x.AppUser)
                .Where(x => x.HelpAdminId == id)
                .FirstOrDefault();
        }
    }
}
