using Microsoft.EntityFrameworkCore;
using ApiRemedio;

namespace ApiRemedio
{
public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

    }

    public DbSet<RemedioEntidade> Remedios => Set <RemedioEntidade>();




}

}