using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Context
{
    public class ProjectContext: DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Pablo Muñoz",
                    Birthday = new DateTime(1950, 7, 23),
                    CityFrom = "Mendoza, AR",
                    Email = "pablo.m@email.com",
                    CreatedTime = new DateTime(1950, 7, 23),
                    LastUpdatedTime = DateTime.Now
                },
                new Author()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Gabriel Garcia Marquez",
                    Birthday = new DateTime(1927, 3, 6),
                    CityFrom = "Aracataca, CO",
                    Email = null,
                    CreatedTime = new DateTime(1950, 7, 23),
                    LastUpdatedTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    PublisherName = "Metanoia Press",
                    Address = "Canadá",
                    MaxNumberBook = 3,
                    PublisherEmail = "editorial@metanoia.com",
                    Telephone = "3158889987",
                    CreatedTime = DateTime.Now,
                    LastUpdatedTime = DateTime.Now
                },
                new Publisher()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    PublisherName = "Sudamericana",
                    Address = "Argentina",
                    MaxNumberBook = -1,
                    PublisherEmail = "editorial@sudamericana.com",
                    Telephone = "3150009987",
                    CreatedTime = DateTime.Now,
                    LastUpdatedTime = DateTime.Now
                }

            );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    Title = "Las mentiras que te cuentan, las verdades que te ocultan",
                    AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    PublisherId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Genre = "Actualidad",
                    Year = 2021,
                    NumberPages = 250,
                    CreatedTime = DateTime.Now,
                    LastUpdatedTime = DateTime.Now
                },
                new Book(){
                    Id = Guid.Parse("d173e20d-159e-9907-9ce9-b0ac2564ad97"),
                    Title = "Cien años de soledad",
                    AuthorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    PublisherId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Genre = "Novela",
                    Year = 1967,
                    NumberPages = 471,
                    CreatedTime = DateTime.Now,
                    LastUpdatedTime = DateTime.Now
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
