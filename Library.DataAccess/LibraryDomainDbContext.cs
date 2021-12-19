using Library.DataAccess.Utils;
using Library.Domain.Common;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class LibraryDomainDbContext : DbContext
    {
        public DbSet<DigitalEntity> DigitalEntities { get; set; }
        public DbSet<Audiobook> Audiobooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Person> Person { get; set; }

        public LibraryDomainDbContext(DbContextOptions<LibraryDomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DigitalEntity>()
                .ToTable("DigitalEntities")
                .HasOne(a => a.Company)
                    .WithMany(p => p.Entities)
                    .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<DigitalEntity>()
                    .HasMany(a => a.Tags)
                    .WithMany(p => p.DigitalEntities)
                    .UsingEntity(p => p.ToTable("DigitalEntityTag"));

            modelBuilder.Entity<Book>()
                .ToTable("Books")
                .HasOne(a => a.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<Audiobook>()
                .ToTable("Audiobooks")
                .HasOne(a => a.Author)
                    .WithMany(p => p.Audiobooks)
                    .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<Magazine>()
                .ToTable("Magazines");

            modelBuilder.Entity<Film>()
                .ToTable("Films")
                .HasOne(a => a.Director)
                .WithMany(p => p.Films)
                .HasForeignKey(p => p.DirectorId);

            modelBuilder.Entity<Person>().HasData(new Person()
            {
                Id = 1,
                FirstName = "J.K.",
                LastName = "Rowling"
            });

            modelBuilder.Entity<Tag>().HasData(new Tag()
            {
                Id = 1,
                Name = "fantastyka"
            });

            modelBuilder.Entity<Tag>().HasData(new Tag()
            {
                Id = 2,
                Name = "pierwszy tom"
            });

            modelBuilder
                .Entity<Tag>()
                .HasMany(p => p.DigitalEntities)
                .WithMany(p => p.Tags)
                .UsingEntity(j => j.HasData(new { TagsId = 1, DigitalEntitiesDigitalEntityId = 1 }));

            modelBuilder
                .Entity<Tag>()
                .HasMany(p => p.DigitalEntities)
                .WithMany(p => p.Tags)
                .UsingEntity(j => j.HasData(new { TagsId = 1, DigitalEntitiesDigitalEntityId = 2 }));

            modelBuilder
                .Entity<Tag>()
                .HasMany(p => p.DigitalEntities)
                .WithMany(p => p.Tags)
                .UsingEntity(j => j.HasData(new { TagsId = 2, DigitalEntitiesDigitalEntityId = 1 }));


            modelBuilder.Entity<Company>().HasData(new Company()
            {
                Id = 1,
                Name = "Pottermore"
            });

            modelBuilder.Entity<Company>().HasData(new Company()
            {
                Id = 2,
                Name = "Media Rodzina"
            });

            modelBuilder.Entity<Audiobook>().HasData(new Audiobook
            {
                AuthorId = 1,
                Length = 100,
                PublicationDate = new DateTime(2020, 1, 2),
                Title = "Harry Potter i Kamień Filozoficzny",
                Description = "Avs",
                DigitalEntityId = 1,
                Image = ImageHelper.ReadImage("wwwroot/img/harry_potter_movie_1.jpg"),
                CompanyId = 1
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                AuthorId = 2,
                PublicationDate = new DateTime(2020, 1, 2),
                Title = "Harry Potter i Komnata Tajemnic",
                Description = "Avdds",
                DigitalEntityId = 2,
                Image = ImageHelper.ReadImage("wwwroot/img/i-harry-potter-i-komnata-tajemnic.jpg"),
                CompanyId = 2
            });
        }
    }
}
