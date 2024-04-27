using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
	public class About
	{
        public int AboutId { get; set; }
        public string FooterAboutText { get; set; }
        public string Text1Title { get; set; }
        public string Text1Content { get; set; }
		public string Text2Title { get; set; }
		public string Text2Content { get; set; }
	}

}
