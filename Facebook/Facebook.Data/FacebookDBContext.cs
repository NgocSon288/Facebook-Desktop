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

        public DbSet<User> Users { set; get; }
        public DbSet<Profile> Profiles { set; get; }

        public static FacebookDBContext Create()
        {
            return new FacebookDBContext();
        }
    }
}