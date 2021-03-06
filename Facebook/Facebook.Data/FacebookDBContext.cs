using Facebook.Model.Models;
using System.Data.Entity;

namespace Facebook.Data
{
    public class FacebookDBContext : DbContext
    {
        public FacebookDBContext() : base("FacebookConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<CommentFeedback> CommentFeedbacks { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<FileColor> FileColors { set; get; }
        public DbSet<Folder> Folders { set; get; }
        public DbSet<MessageQueue> MessageQueues { set; get; }
        public DbSet<Message> Messages { set; get; }
        public DbSet<MessageSetting> MessageSettings { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostStatus> PostStatuses { set; get; }
        public DbSet<Profile> Profiles { set; get; }
        public DbSet<User> Users { set; get; }

        public static FacebookDBContext Create()
        {
            return new FacebookDBContext();
        }
    }
}