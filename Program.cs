using FlyweightForest.Factories;
using FlyweightForest.Models;

namespace FlyweightForest;

class Program
{
    static void Main()
    {
        const int TOTAL_ARVORES = 10_000;
        const float TAMANHO_FLORESTA = 1000f;

        var aleatorio = new Random(42);
        var floresta = new List<Arvore>(TOTAL_ARVORES);

        Console.WriteLine("=== Criando floresta com Flyweight ===\n");

        for (int i = 0; i < TOTAL_ARVORES; i++)
        {
            var especie = FabricaEspecies.PegarAleatoria(aleatorio);
            float posX = (float)(aleatorio.NextDouble() * TAMANHO_FLORESTA);
            float posY = (float)(aleatorio.NextDouble() * TAMANHO_FLORESTA);

            floresta.Add(new Arvore(especie, aleatorio, posX, posY));
        }

        Console.WriteLine("--- Primeiras 10 árvores ---");
        for (int i = 0; i < 10; i++)
            floresta[i].Imprimir();

        Console.WriteLine($"\n--- Estatísticas ---");
        Console.WriteLine($"Total de árvores:             {floresta.Count:N0}");
        Console.WriteLine($"Espécies no pool (Flyweight): {FabricaEspecies.TamanhoPool}");
        Console.WriteLine($"Altura média:                 {Media(floresta, a => a.Altura):F2} m");
        Console.WriteLine($"Circunferência média:         {Media(floresta, a => a.Circunferencia):F2} cm");
        Console.WriteLine($"Idade média:                  {Media(floresta, a => a.Idade):F1} anos");
    }

    static double Media<T>(List<Arvore> lista, Func<Arvore, T> seletor) where T : struct
    {
        double soma = 0;
        foreach (var arvore in lista)
            soma += Convert.ToDouble(seletor(arvore));

        return soma / lista.Count;
    }
}
