using Autofac;
using Facebook.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class RepositoryConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentFeedbackRepository>().As<ICommentFeedbackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageQueueRepository>().As<IMessageQueueRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageSettingRepository>().As<IMessageSettingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostStatusRepository>().As<IPostStatusRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileRepository>().As<IProfileRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
