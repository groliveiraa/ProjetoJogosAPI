using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repository
{
    public class JogoContext : DbContext
    {
        public JogoContext(DbContextOptions<JogoContext> options) : base(options) { }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<ClassificacaoIndicativa> Classificacoes { get; set; }
        public DbSet<JogoConsole> JogoConsoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogoConsole>(entity =>
            {
                entity.HasKey(e => new { e.VideoGameId, e.JogoId });
            });
        }
    }
}
