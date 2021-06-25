using Autofac;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class ServiceConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<CommentFeedbackService>().As<ICommentFeedbackService>().InstancePerLifetimeScope();
            builder.RegisterType<FolderService>().As<IFolderService>().InstancePerLifetimeScope();
            builder.RegisterType<MessageService>().As<IMessageService>().InstancePerLifetimeScope();
            builder.RegisterType<MessageQueueService>().As<IMessageQueueService>().InstancePerLifetimeScope();
            builder.RegisterType<MessageSettingService>().As<IMessageSettingService>().InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<PostStatusService>().As<IPostStatusService>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileService>().As<IProfileService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
