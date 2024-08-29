// Solicita ao usuário que insira um valor inteiro positivo
Console.Write("Digite um valor inteiro positivo: ");
int valorLimite = Convert.ToInt32(Console.ReadLine());

// Verifica se o valor é positivo
if (valorLimite <= 0)
{
    Console.WriteLine("Por favor, insira um valor positivo.");
    return;
}

// Inicializa os dois primeiros números da sequência de Fibonacci
int anterior = 0;
int atual = 1;

// Imprime o primeiro número da sequência
Console.Write("Sequência de Fibonacci: " + anterior);

// Continua imprimindo os números da sequência enquanto eles forem menores ou iguais ao valor limite
while (atual <= valorLimite)
{
    Console.Write(", " + atual);

    // Calcula o próximo número da sequência
    int proximo = anterior + atual;
    anterior = atual;
    atual = proximo;
}

// Finaliza a linha
Console.WriteLine();