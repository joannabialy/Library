using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class LibraryIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public LibraryIdentityDbContext(DbContextOptions<LibraryIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
