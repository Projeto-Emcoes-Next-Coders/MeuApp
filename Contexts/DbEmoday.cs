using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts
{
    class DbEmoday : DbContext
    {
        public DbSet<Credencial> Credencials { get; set; }
        public DbSet<Gatilho> Gatilhos { get; set; }
        public DbSet<Reacao> Reacaos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbEmoday(DbContextOptions<DbEmoday> options) : base(options){}

        public DbEmoday()
        {
        }

        protected override void OnModelCreating(ModelBuilder construtor)
        {
            //1:1
            construtor.Entity<Credencial>()
                .HasOne(c => c.Usuario)
                .WithOne(c => c.Credencial)
                .HasForeignKey<Credencial>(coluna => coluna.IdUsuario)
                .HasConstraintName("Fk_Endereco_Usuario");

            //1:N
            construtor.Entity<Gatilho>()
                .HasOne(c => c.Usuario)
                .WithMany(c => c.Gatilhos)
                .HasForeignKey(coluna => coluna.IdUsuario)
                .HasConstraintName("Fk_Usuario_Emocao");

            //1:N
            construtor.Entity<Gatilho>()
                .HasOne(c => c.Reacao)
                .WithMany(c => c.Gatilhos)
                .HasForeignKey(coluna => coluna.IdReacao)
                .HasConstraintName("Fk_Reacao_Emocao");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder definicoesContrutor)
        {
            // definicoesContrutor.UseNpgsql("");
            definicoesContrutor.UseInMemoryDatabase("MinhaLoja");
        }
    }
}