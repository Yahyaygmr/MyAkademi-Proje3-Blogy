using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
	public class ContactUs
	{
        public int ContactUsId { get; set; }
        public string Location { get; set; }
        public string OpenHours { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
