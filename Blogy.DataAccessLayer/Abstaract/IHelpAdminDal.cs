using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstaract
{
    public interface IHelpAdminDal : IGenericDal<HelpAdmin>
    {
        List<HelpAdmin> GetHelpAdminWithAppUser();
        HelpAdmin GetHelpAdminWithAppUserById(int id);
    }
}
