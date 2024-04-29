using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class HelpAdmin
    {
        public int HelpAdminId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
