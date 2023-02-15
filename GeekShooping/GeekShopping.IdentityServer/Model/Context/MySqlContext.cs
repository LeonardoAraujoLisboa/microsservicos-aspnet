using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>//Model é o do banco e o Models é o da tela
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
    }
}
