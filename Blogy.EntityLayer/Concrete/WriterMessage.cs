using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class WriterMessage
    {
        public int WriterMessageId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string RecieverMail { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime SendDate { get; set; }
        public bool Status { get; set; }
        public bool IsRead { get; set; }
    }
}
