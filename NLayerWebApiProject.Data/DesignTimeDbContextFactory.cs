using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NLayerWebApiProject.Data
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString =
                "Server=DESKTOP-NOOAEV8\\SQLEXPRESS;Database=NLayerApiAppDb;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString, o =>
            {
                o.MigrationsAssembly("NLayerWebApiProject.Data");
            });
            return new AppDbContext(builder.Options);
        }
    }
}