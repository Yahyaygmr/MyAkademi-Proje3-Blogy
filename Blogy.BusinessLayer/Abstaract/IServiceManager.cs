using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstaract
{
    public interface IServiceManager
    {
        IAboutService AboutService { get; }
        IArticleService ArticleService { get; }
        ICategoryService CategoryService { get; }
        ICommentService CommentService { get; }
        IContactUsService ContactUsService { get; }
        IHelpAdminService HelpAdminService { get; }
        IMessageService MessageService { get; }
        INotificationService NotificationService { get; }
        ISocialMediaService SocialMediaService { get; }
        ITagService TagService { get; }
    }
}
