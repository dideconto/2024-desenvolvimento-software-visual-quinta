namespace API.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
