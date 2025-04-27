using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HelpApp.Infra.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-F68GVQT\\SQLEXPRESS;Initial Catalog=avalicaomigueltp2;Integrated Security=True;Trust Server Certificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
