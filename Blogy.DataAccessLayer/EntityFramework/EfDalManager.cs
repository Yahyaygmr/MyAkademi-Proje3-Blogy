using Blogy.DataAccessLayer.Abstaract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfDalManager : IDalManager
    {
        private readonly IAboutDal _aboutDal;
        private readonly IArticleDal _articleDal;
        private readonly ICategoryDal _categoryDal;
        private readonly ICommentDal _commentDal;
        private readonly IContactUsDal _contactUsDal;
        private readonly IHelpAdminDal _helpAdminDal;
        private readonly IMessageDal _messageDal;
        private readonly INotificationDal _notificationDal;
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly ITagDal _tagDal;

        public EfDalManager(IAboutDal aboutDal, IArticleDal articleDal, ICategoryDal categoryDal, ICommentDal commentDal, IContactUsDal contactUsDal, IHelpAdminDal helpAdminDal, IMessageDal messageDal, INotificationDal notificationDal, ISocialMediaDal socialMediaDal, ITagDal tagDal)
        {
            _aboutDal = aboutDal;
            _articleDal = articleDal;
            _categoryDal = categoryDal;
            _commentDal = commentDal;
            _contactUsDal = contactUsDal;
            _helpAdminDal = helpAdminDal;
            _messageDal = messageDal;
            _notificationDal = notificationDal;
            _socialMediaDal = socialMediaDal;
            _tagDal = tagDal;
        }

        public IAboutDal About => _aboutDal;

        public IArticleDal Article => _articleDal;

        public ICategoryDal Category => _categoryDal;

        public ICommentDal Comment => _commentDal;

        public IContactUsDal ContactUs => _contactUsDal;

        public IHelpAdminDal HelpAdmin => _helpAdminDal;

        public IMessageDal Message => _messageDal;

        public INotificationDal Notification => _notificationDal;

        public ISocialMediaDal SocialMedia => _socialMediaDal;

        public ITagDal Tag => _tagDal;
    }
}
