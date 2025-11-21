using Microsoft.EntityFrameworkCore;
using InvestFlowCaixa.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InvestFlowCaixa.Infrastructure.Data
{
    public class InvestimentosDbContext : DbContext
    {
        public InvestimentosDbContext(DbContextOptions<InvestimentosDbContext> options) : base(options)
        {
        }

        // ============================
        // DbSets (Tabelas)
        // ============================
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoInvestimento> ProdutosInvestimento { get; set; }
        public DbSet<PerfilRisco> PerfisRisco { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<HistoricoInvestimento> HistoricoInvestimentos { get; set; }
        public DbSet<TelemetriaServico> TelemetriaServicos { get; set; }

        // ============================
        // ModelBuilder
        // ============================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvestimentosDbContext).Assembly);

        // ============================
        // Tabelas
        // ============================
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<ProdutoInvestimento>().ToTable("ProdutosInvestimento");
            modelBuilder.Entity<PerfilRisco>().ToTable("PerfisRisco");
            modelBuilder.Entity<Simulacao>().ToTable("Simulacoes");
            modelBuilder.Entity<HistoricoInvestimento>().ToTable("HistoricoInvestimentos");
            modelBuilder.Entity<TelemetriaServico>().ToTable("TelemetriaServicos");

            modelBuilder.Entity<HistoricoInvestimento>()
                .Property(h => h.Id)
                .ValueGeneratedOnAdd();

            // ============================
            // Relacionamentos
            // ============================

            // Cliente → Simulacao (1:N)
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Simulacoes)
                .WithOne(s => s.Cliente)
                .HasForeignKey(s => s.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Perfil)
                .WithMany()
                .HasForeignKey(c => c.PerfilId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente → HistoricoInvestimento (1:N)
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Historico)
                .WithOne(h => h.Cliente)
                .HasForeignKey(h => h.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProdutoInvestimento → Simulação (1:N)
            modelBuilder.Entity<ProdutoInvestimento>()
                .HasMany<Simulacao>()
                .WithOne(s => s.ProdutoInvestimento)
                .HasForeignKey(s => s.ProdutoInvestimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Índices recomendados
            // ============================
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CPF).IsUnique();

            modelBuilder.Entity<Simulacao>()
                .HasIndex(s => new { s.ClienteId, s.DataSimulacao });

            modelBuilder.Entity<TelemetriaServico>()
                .HasIndex(t => t.NomeServico);

            // ============================
            // Precision para decimais
            // ============================
            modelBuilder.Entity<Cliente>()
                .Property(c => c.RendaMensal)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.VolumeInvestimentos)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.Rentabilidade)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ProdutoInvestimento>()
                .Property(p => p.MinValor)
                .HasPrecision(18, 2);


            modelBuilder.Entity<Simulacao>()
                .Property(s => s.ValorFinal)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Simulacao>()
                .Property(s => s.RentabilidadeEfetiva)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Simulacao>()
                .Property(s => s.ValorInvestido)
                .HasPrecision(18, 2);

            modelBuilder.Entity<HistoricoInvestimento>()
                .Property(h => h.Valor)
                .HasPrecision(18, 2);

            modelBuilder.Entity<HistoricoInvestimento>()
                .Property(h => h.Rentabilidade)
                .HasPrecision(18, 4);

            // ============================
            // Seed Data - Perfis de Risco
            // ============================
            modelBuilder.Entity<PerfilRisco>().HasData(
                new PerfilRisco
                {
                    Id = 1,
                    Nome = "Conservador",
                    Descricao = "Baixa movimentação e foco em liquidez."
                },
                new PerfilRisco
                {
                    Id = 2,
                    Nome = "Moderado",
                    Descricao = "Equilíbrio entre liquidez e rentabilidade."
                },
                new PerfilRisco
                {
                    Id = 3,
                    Nome = "Agressivo",
                    Descricao = "Busca por alta rentabilidade assumindo maior risco."
                }
            );

        }
    }
}
