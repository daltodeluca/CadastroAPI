using CadastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonEntity>(builder =>
            {
                builder.OwnsOne(p => p.Name, name =>
                {
                    name.Property(n => n.FirstName)
                        .HasColumnName("FirstName")
                        .HasMaxLength(100)
                        .IsRequired();

                    name.Property(n => n.LastName)
                        .HasColumnName("LastName")
                        .HasMaxLength(100)
                        .IsRequired();
                });

                builder.OwnsOne(p => p.Email, email =>
                {
                    email.Property(e => e.EmailAddress)
                        .HasColumnName("Email")
                        .HasMaxLength(200)
                        .IsRequired();
                });

                builder.OwnsOne(p => p.Phone, phone =>
                {
                    phone.Property(ph => ph.Number)
                        .HasColumnName("Phone")
                        .HasMaxLength(20)
                        .IsRequired();
                });

                builder.OwnsOne(p => p.Document, doc =>
                {
                    doc.Property(d => d.Number)
                        .HasColumnName("Document")
                        .HasMaxLength(20)
                        .IsRequired();
                    doc.Property(d => d.Type)
                        .HasColumnName("DocumentType")
                        .IsRequired();
                });

                builder.OwnsOne(p => p.Address, addr =>
                {
                    addr.Property(a => a.Street)
                        .HasColumnName("Street")
                        .HasMaxLength(200);

                    addr.Property(a => a.Number)
                        .HasColumnName("Number")
                        .HasMaxLength(20);

                    addr.Property(a => a.Neighborhood)
                        .HasColumnName("Neighborhood")
                        .HasMaxLength(100);

                    addr.Property(a => a.City)
                        .HasColumnName("City")
                        .HasMaxLength(100);

                    addr.Property(a => a.State)
                        .HasColumnName("State")
                        .HasMaxLength(50);

                    addr.Property(a => a.Country)
                        .HasColumnName("Country")
                        .HasMaxLength(100);

                    addr.Property(a => a.ZipCode)
                        .HasColumnName("ZipCode")
                        .HasMaxLength(20);
                });
            });
            modelBuilder.Entity<UserEntity>(builder =>
            {
                builder.OwnsOne(u => u.Username, username =>
                {
                    username.Property(u => u.Name)
                            .HasColumnName("Username")
                            .HasMaxLength(100)
                            .IsRequired();
                });

                builder.OwnsOne(u => u.Password, password =>
                {
                    password.Property(p => p.Hash)
                            .HasColumnName("PasswordHash")
                            .IsRequired();

                    password.Property(p => p.Salt)
                            .HasColumnName("PasswordSalt")
                            .IsRequired();
                });
            });
        }
    }
}