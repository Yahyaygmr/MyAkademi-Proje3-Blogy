using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstaract
{
    public interface IDalManager
    {
        IAboutDal About {  get; }
        IArticleDal Article { get; }
        ICategoryDal Category { get; }
        ICommentDal Comment { get; }
        IContactUsDal ContactUs { get; }
        IHelpAdminDal HelpAdmin { get; }
        IMessageDal Message { get; }
        INotificationDal Notification { get; }
        ISocialMediaDal SocialMedia { get; }
        ITagDal Tag { get; }

    }
}
