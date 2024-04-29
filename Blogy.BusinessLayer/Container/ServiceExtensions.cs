using Blogy.BusinessLayer.Abstaract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Abstaract;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Container
{
    public static class ServiceExtensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDalManager, EfDalManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<IArticleService, ArticleManager>();

            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<ITagDal, EfTagDal>();
            services.AddScoped<ITagService, TagManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IContactUsDal, EfContactUsDal>();
            services.AddScoped<IContactUsService, ContactUsManager>();

            services.AddScoped<IHelpAdminDal, EfHelpAdminDal>();
            services.AddScoped<IHelpAdminService, HelpAdminManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<INotificationDal, EfNotificationDal>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

        }
    }
}
