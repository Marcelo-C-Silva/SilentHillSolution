namespace SilentHill.Shared;

public class CriaturaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string JogoOrigem { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public int NivelPerigo { get; set; }
}