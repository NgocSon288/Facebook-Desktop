﻿using Autofac;
using Facebook.DAO;

namespace Facebook.Configure.Autofac
{
    public static class DAOConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<CommentDAO>().As<ICommentDAO>().InstancePerLifetimeScope();
            builder.RegisterType<CommentFeedbackDAO>().As<ICommentFeedbackDAO>().InstancePerLifetimeScope();
            builder.RegisterType<PostDAO>().As<IPostDAO>().InstancePerLifetimeScope();
            builder.RegisterType<PostStatusDAO>().As<IPostStatusDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileDAO>().As<IProfileDAO>().InstancePerLifetimeScope();
            builder.RegisterType<UserDAO>().As<IUserDAO>().InstancePerLifetimeScope();
        }
    }
}