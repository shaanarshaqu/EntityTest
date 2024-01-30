using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityTest.Models
{
    public class StudentsDb:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connnectiostring;
        public DbSet<StudentsDTO> Studentsdbset { get; set; }
        public DbSet<DepartmentDTO> DepartmentDTOs { get; set; }

        public StudentsDb(IConfiguration configuration)
        {
            _configuration = configuration;
            connnectiostring = _configuration["ConnectionStrings:DefaultConnection"];
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connnectiostring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsDTO>()
                .HasOne(s => s.departmentDTO)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.DepartmentId);
        }
    }
}
