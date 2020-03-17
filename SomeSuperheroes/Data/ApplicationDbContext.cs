using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SomeSuperheroes.Models;

namespace SomeSuperheroes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Superhero> superheroes;

        public DbSet<SomeSuperheroes.Models.Superhero> Superhero { get; set; }
    }
}
