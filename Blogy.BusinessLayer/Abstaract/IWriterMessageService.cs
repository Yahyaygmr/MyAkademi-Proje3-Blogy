using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstaract
{
    public interface IWriterMessageService : IGenericService<WriterMessage>
    {
        List<WriterMessage> TGetWriterMessagesByUser(AppUser user);
        WriterMessage TGetWriterMessagesByIdWithUser(int id);
    }
}
