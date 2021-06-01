using System;

namespace Facebook.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        FacebookDBContext Init();
    }
}