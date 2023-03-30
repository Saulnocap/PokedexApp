using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options) : base(options){ }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Type1> Type1s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            #region FluentApi

            #region Tablas

            modelbuilder
                .Entity<Pokemon>().ToTable("Pokemones");
            modelbuilder
                .Entity<Region>().ToTable("Regiones");
            modelbuilder
                .Entity<Type1>().ToTable("Tipos");

            #endregion

            #region PrimaryKey

            modelbuilder
                .Entity<Pokemon>()
                .HasKey(pokemon => pokemon.Id);
            modelbuilder
                .Entity<Region>().HasKey(region => region.Id);
            modelbuilder
                .Entity<Type1>().HasKey(type1 => type1.Id);
            #endregion

            #region Relaciones

            modelbuilder
                .Entity<Region>()
                .HasMany<Pokemon>(region => region.Pokemon)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder
                .Entity<Type1>()
                .HasMany<Pokemon>(type1 => type1.Pokemon)
                .WithOne(pokemon => pokemon.Type1)
                .HasForeignKey(pokemon => pokemon.Type1id)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region configprop

            #region Pokemon

            modelbuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name).IsRequired()
                .HasMaxLength(50);
            modelbuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.RegionId).IsRequired();
            modelbuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.ImgUrl).IsRequired();
            modelbuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Type1id).IsRequired();

            #endregion

            #region Region

            modelbuilder.Entity<Region>()
                .Property(region => region.Name).IsRequired()
                .HasMaxLength(50);

            #endregion

            #region Tipo1

            modelbuilder.Entity<Type1>()
                .Property(type1 => type1.Name).IsRequired();

            #endregion
            #endregion
            #endregion
    }
    }
}
