namespace API.Models;

public class Categoria
{
    public string CategoriaId { get; set; } = Guid.NewGuid().ToString();
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
