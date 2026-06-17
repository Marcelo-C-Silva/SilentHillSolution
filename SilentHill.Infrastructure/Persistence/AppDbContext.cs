using Microsoft.EntityFrameworkCore;
using SilentHill.Domain;

namespace SilentHill.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Criatura> Criaturas => Set<Criatura>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Criatura>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Descricao).HasMaxLength(2000);
            entity.Property(e => e.JogoOrigem).HasMaxLength(200);
            entity.Property(e => e.ImagemUrl).HasMaxLength(1000);
        });

        modelBuilder.Entity<Criatura>().HasData(
            new Criatura
            {
                Id = 1,
                Nome = "Pyramid Head",
                Descricao = "O executor de Silent Hill 2. Uma figura misteriosa usando um capacete metálico em forma de pirâmide que carrega um enorme facão como instrumento de julgamento e punição.",
                JogoOrigem = "Silent Hill 2",
                NivelPerigo = 5,
                ImagemUrl = "https://static.wikia.nocookie.net/silent/images/c/c9/Red_Pyramid.png/revision/latest?cb=20241231221947"
            },
            new Criatura
            {
                Id = 2,
                Nome = "Bubble Head Nurse",
                Descricao = "Enfermeiras sinistras que vagam pelos corredores do Hospital Brookhaven. Seus rostos cobertos por máscaras de gaze e seus movimentos erráticos as tornam imprevisíveis.",
                JogoOrigem = "Silent Hill 2",
                NivelPerigo = 3,
                ImagemUrl = "https://static.wikia.nocookie.net/silent/images/7/71/Hellooo_nurse%21.png/revision/latest?cb=20131222015921"
            }
        );
    }
}
