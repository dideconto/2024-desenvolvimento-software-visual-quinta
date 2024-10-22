namespace Diogo.Models;

public class Folha
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public double SalarioLiquido { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoIRRF { get; set; }
    public double ImpostoINSS { get; set; }
    public double ImpostoFGTS { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
}
