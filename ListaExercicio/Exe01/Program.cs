// Solicita ao usuário que insira a altura do retângulo
Console.Write("Digite a altura do retângulo: ");
double altura = Convert.ToDouble(Console.ReadLine());

// Solicita ao usuário que insira a largura do retângulo
Console.Write("Digite a largura do retângulo: ");
double largura = Convert.ToDouble(Console.ReadLine());

// Calcula a área do retângulo
double area = altura * largura;

// Exibe a área calculada
Console.WriteLine($"A área do retângulo é: {area}");