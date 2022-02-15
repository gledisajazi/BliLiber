using BliLiberProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BliLiberProject.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
    }
    
}
