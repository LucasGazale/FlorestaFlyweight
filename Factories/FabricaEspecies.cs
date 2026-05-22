using System.Collections.Generic;
using FlyweightForest.Models;

namespace FlyweightForest.Factories;

public static class FabricaEspecies
{
    private static readonly Dictionary<string, EspecieArvore> _pool = new();

    private static readonly (string nome, string cor,
                              float altMin, float altMax,
                              float cirMin, float cirMax,
                              int idadeMin, int idadeMax)[] _dados =
    {
        ("Carvalho", "Verde escuro", 10, 40, 80, 300, 100, 1000),
        ("Pinheiro", "Verde", 15, 50, 60, 200, 80, 600),
        ("Eucalipto", "Verde claro", 20, 60, 40, 150, 10, 200),
        ("Cedro", "Verde azulado", 20, 50, 70, 250, 80, 500),
        ("Ipê amarelo", "Amarelo", 5, 20, 30, 120, 50, 200)
        // coloque o resto aqui
    };

    public static EspecieArvore PegarAleatoria(Random aleatorio)
    {
        var entrada = _dados[aleatorio.Next(_dados.Length)];

        if (!_pool.ContainsKey(entrada.nome))
        {
            _pool[entrada.nome] = new EspecieArvore(
                entrada.nome, entrada.cor,
                entrada.altMin, entrada.altMax,
                entrada.cirMin, entrada.cirMax,
                entrada.idadeMin, entrada.idadeMax);
        }

        return _pool[entrada.nome];
    }

    public static int TamanhoPool => _pool.Count;
}
