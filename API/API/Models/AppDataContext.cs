using Microsoft.EntityFrameworkCore;

namespace API.Models;

//Implementar a henraça da classe DbContext
public class AppDataContext : DbContext
{
    //Declarar todas as classes de modelo que vão virar tabelas no banco de dados
    public DbSet<Produto> Produtos { get; set; }

    //Qual o banco de dados que será utilizado
    //String de conexão
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}
