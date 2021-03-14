using LibraryMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
  
namespace LibraryMS.Data
{
    public class AppIdentityDbContext : IdentityDbContext<Account>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base(options) { }
    }
}
