using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ElearingEnglis.DataCon.Module;

namespace ElearingEnglis.DataCon;

public class DBCon : IdentityDbContext
{

    public DbSet<Patient> patients {get; set;}
    public DbSet<Appointment> appointments {get; set;}
    public DbSet<Doctor> doctors {get; set;}
    public DbSet<Drug> drugs { get; set; }
    public DBCon(DbContextOptions<DBCon> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Drug>()
            .Property(d => d.PriceEgp)
            .HasPrecision(10, 2);
    }
}
