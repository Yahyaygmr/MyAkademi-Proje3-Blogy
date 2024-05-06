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
    public class HelpAdminManager : IHelpAdminService
    {
        private readonly IHelpAdminDal _helpAdminDal;

        public HelpAdminManager(IHelpAdminDal helpAdminDal)
        {
            _helpAdminDal = helpAdminDal;
        }

        public DbSet<HelpAdmin> GetTContext()
        {
            return _helpAdminDal.GetTContext();
        }

        public void TDelete(int id)
        {
            _helpAdminDal.Delete(id);
        }

        public HelpAdmin TGetById(int id)
        {
            return _helpAdminDal.GetById(id);
        }

        public List<HelpAdmin> TGetHelpAdminWithAppUser()
        {
            return _helpAdminDal.GetHelpAdminWithAppUser();
        }

        public HelpAdmin TGetHelpAdminWithAppUserById(int id)
        {
            return _helpAdminDal.GetHelpAdminWithAppUserById(id);
        }

        public List<HelpAdmin> TGetListAll()
        {
            return _helpAdminDal.GetListAll();
        }

        public void TInsert(HelpAdmin entity)
        {
            _helpAdminDal.Insert(entity);
        }

        public void TUpdate(HelpAdmin entity)
        {
            _helpAdminDal.Update(entity);
        }
    }
}
