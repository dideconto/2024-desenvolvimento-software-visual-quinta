// Taxas de câmbio
double taxaDolar = 5.17;
double taxaEuro = 6.14;
double taxaPesoArgentino = 0.05;

// Solicita ao usuário o valor em reais
Console.Write("Digite o valor em reais (R$): ");
double valorEmReais = Convert.ToDouble(Console.ReadLine());

// Converte para Dólar
double valorEmDolar = valorEmReais / taxaDolar;

// Converte para Euro
double valorEmEuro = valorEmReais / taxaEuro;

// Converte para Peso Argentino
double valorEmPesoArgentino = valorEmReais / taxaPesoArgentino;

// Exibe os valores convertidos
Console.WriteLine($"\nValor em Dólar: ${valorEmDolar:F2}");
Console.WriteLine($"Valor em Euro: €{valorEmEuro:F2}");
Console.WriteLine($"Valor em Peso Argentino: ${valorEmPesoArgentino:F2}");