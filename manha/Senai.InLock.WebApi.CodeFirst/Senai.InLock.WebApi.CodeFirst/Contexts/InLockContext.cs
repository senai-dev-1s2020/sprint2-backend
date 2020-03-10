using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre API e Banco de Dados
    /// </summary>
    public class InLockContext : DbContext
    {
        // Define as entidades do banco de dados
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        /// <summary>
        /// Define as opções de construção do banco
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NJ6LHN1\\SQLDEVELOPER; Database=InLock_Games_CodeFirst; Integrated Security=True;");
            //optionsBuilder.UseSqlServer("Server=DESKTOP-GCOFA7F\\SQLEXPRESS; Database=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Define o modelo de criação do banco
        /// </summary>
        /// <param name="modelBuilder">Objeto com os modelos que serão criados</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define as entidades já com dados
            modelBuilder.Entity<TiposUsuario>(entity => {
                entity
                .HasIndex(tu => tu.Titulo)
                .IsUnique();

                entity.HasData(
                new TiposUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });
            });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios { IdEstudio = 1, NomeEstudio = "Blizzard" },
                new Estudios { IdEstudio = 2, NomeEstudio = "Rockstar Studios" },
                new Estudios { IdEstudio = 3, NomeEstudio = "Square Enix" });

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Jogo eletrônico de ação-aventura western",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
