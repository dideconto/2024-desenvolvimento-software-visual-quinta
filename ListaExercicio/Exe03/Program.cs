// Solicita ao usuário o primeiro número inteiro
Console.Write("Digite o primeiro número inteiro: ");
int numero1 = Convert.ToInt32(Console.ReadLine());

// Solicita ao usuário o segundo número inteiro
Console.Write("Digite o segundo número inteiro: ");
int numero2 = Convert.ToInt32(Console.ReadLine());

// Verifica qual número é o maior e qual é o menor
if (numero1 > numero2)
{
    Console.WriteLine($"\nO maior número é: {numero1}");
    Console.WriteLine($"O menor número é: {numero2}");
}
else if (numero1 < numero2)
{
    Console.WriteLine($"\nO maior número é: {numero2}");
    Console.WriteLine($"O menor número é: {numero1}");
}
else
{
    Console.WriteLine("\nOs números são iguais.");
}