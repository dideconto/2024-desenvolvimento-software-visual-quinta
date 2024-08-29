// Solicita ao usuário que insira a idade
Console.Write("Digite a idade da pessoa: ");
int idade = Convert.ToInt32(Console.ReadLine());

// Verifica a faixa etária e exibe a mensagem correspondente
if (idade <= 13)
{
    Console.WriteLine("Criança");
}
else if (idade > 13 && idade <= 18)
{
    Console.WriteLine("Adolescente");
}
else if (idade > 18 && idade <= 60)
{
    Console.WriteLine("Adulto");
}
else if (idade > 60)
{
    Console.WriteLine("Idoso");
}