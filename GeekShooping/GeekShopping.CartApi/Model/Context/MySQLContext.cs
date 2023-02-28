using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartApi.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext>options) : base(options) {}
        public DbSet<Product> Products { get; set; } //essa é outra migration que ai ele criou no banco a tabela Product. No terminal coloco add-migration AddProductDataTableOnDB. E para adicionar no banco de dados mesmo, voce abre o terminal dentro do projeto e coloca dotnet ef database update, e ai ele vai criar essa tabela, caso dê erro eu tenho que instalar globalmente o dotnet tool com o comando dotnet tool install --global dotnet-ef
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
    }
}
