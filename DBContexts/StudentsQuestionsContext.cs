using ConsultaTrabajadores.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsultaTrabajadores.API.DBContexts
{
    public class WorkersQuestionsContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Employer> Employers { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }


        public WorkersQuestionsContext(DbContextOptions<WorkersQuestionsContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Worker>().HasData(
                new Worker
                {
                    LastName = "Bologna",
                    Name = "Nicolas",
                    Email = "nbologna31@gmail.com",
                    UserName = "nbologna_worker",
                    Password = "123456",
                    Id = 1
                },
                new Worker
                {
                    LastName = "Perez",
                    Name = "Juan",
                    Email = "Jperez@gmail.com",
                    UserName = "jperez",
                    Password = "123456",
                    Id = 2
                },
                new Worker
                {
                    LastName = "Garcia",
                    Name = "Pedro",
                    Email = "pgarcia@gmail.com",
                    UserName = "pgarcia",
                    Password = "123456",
                    Id = 3
                });

            modelBuilder.Entity<Employer>().HasData(
                new Employer
                {
                    LastName = "Bologna",
                    Name = "Nicolas",
                    Email = "nbologna31@gmail.com",
                    UserName = "nbologna_employer",
                    Password = "123456",
                    Id = 4
                },
                new Employer
                {
                    LastName = "Paez",
                    Name = "Pablo",
                    Email = "ppaez@gmail.com",
                    UserName = "ppaez",
                    Password = "123456",
                    Id = 5
                });

            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Id = 1,
                    Name = "Sucursal Oroño",
                    Quarter = "Tercer"
                },
                new Branch
                {
                    Id = 2,
                    Name = "Sucursal Pellegrini",
                    Quarter = "Tercer"
                });

            modelBuilder.Entity<Branch>()
                .HasMany(x => x.Workers)
                .WithMany(x => x.BranchesAttended)
                .UsingEntity(j => j
                    .ToTable("WorkersBranchesAttended")
                    .HasData(new[]
                        {
                            new { WorkersId = 1, BranchesAttendedId = 1},
                            new { WorkersId = 1, BranchesAttendedId = 2},
                        }
                    ));

            modelBuilder.Entity<Branch>()
                .HasMany(x => x.Employers)
                .WithMany(x => x.Branches)
                .UsingEntity(j => j
                    .ToTable("EmployerBranch")
                    .HasData(new[]
                        {
                            new { EmployersId = 4, BranchesId = 1},
                            new { EmployersId= 5, BranchesId = 1},
                            new { EmployersId = 4, BranchesId = 2},
                        }
                    ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
