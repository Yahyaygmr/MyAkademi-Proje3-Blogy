using Blogy.BusinessLayer.Abstaract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAboutService _aboutService;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IContactUsService _contactUsService;
        private readonly IHelpAdminService _helpAdminService;
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly ITagService _tagService;

        public ServiceManager(IAboutService aboutService, IArticleService articleService, ICategoryService categoryService, ICommentService commentService, IContactUsService contactUsService, IHelpAdminService helpAdminService, IMessageService messageService, INotificationService notificationService, ISocialMediaService socialMediaService, ITagService tagService)
        {
            _aboutService = aboutService;
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
            _contactUsService = contactUsService;
            _helpAdminService = helpAdminService;
            _messageService = messageService;
            _notificationService = notificationService;
            _socialMediaService = socialMediaService;
            _tagService = tagService;
        }

        public IAboutService AboutService => _aboutService;

        public IArticleService ArticleService => _articleService;

        public ICategoryService CategoryService => _categoryService;

        public ICommentService CommentService => _commentService;

        public IContactUsService ContactUsService => _contactUsService;

        public IHelpAdminService HelpAdminService => _helpAdminService;

        public IMessageService MessageService => _messageService;

        public INotificationService NotificationService => _notificationService;

        public ISocialMediaService SocialMediaService => _socialMediaService;

        public ITagService TagService => _tagService;
    }
}
