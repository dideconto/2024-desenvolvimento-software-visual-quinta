//Criar um vetor de valores inteiros
int tamanho = 10;
int[] vetor = new int[tamanho];

//Percorrer o vetor
Random random = new Random();
for (int i = 0; i < vetor.Length; i++)
{
    //Gerar o valor aleatório
    //Guardar o valor em uma posição do vetor
    vetor[i] = random.Next(1000);
}

//Imprimir o vetor com valores aleatórios
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

//Ordernar o vetor com o Bubble Sort
bool troca = false;
do
{
    troca = false;
    for (int i = 0; i < vetor.Length - 1; i++)
    {
        if (vetor[i] > vetor[i + 1])
        {
            //Troca
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
            troca = true;
        }
    }
} while (troca == true);

//Imprimir o vetor com valores ordenados
Console.WriteLine("\n");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}