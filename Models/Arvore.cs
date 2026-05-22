using FlyweightForest.Models;

namespace FlyweightForest.Models;

public class Arvore
{
    private readonly EspecieArvore _especie;

    public float Altura { get; }
    public float Circunferencia { get; }
    public int Idade { get; }
    public float PosicaoX { get; }
    public float PosicaoY { get; }

    public Arvore(EspecieArvore especie, Random aleatorio, float posX, float posY)
    {
        _especie = especie;
        PosicaoX = posX;
        PosicaoY = posY;

        Altura = especie.AlturaMinima +
                 (float)aleatorio.NextDouble() * (especie.AlturaMaxima - especie.AlturaMinima);

        Circunferencia = especie.CircunfMinima +
                         (float)aleatorio.NextDouble() * (especie.CircunfMaxima - especie.CircunfMinima);

        Idade = aleatorio.Next(especie.IdadeMinima, especie.IdadeMaxima + 1);
    }

    public void Imprimir()
    {
        Console.WriteLine(
            $"[{_especie.Nome,-18}] Cor: {_especie.Cor,-14} | " +
            $"Altura: {Altura:F1}m | Circunf: {Circunferencia:F0}cm | " +
            $"Idade: {Idade} anos | Pos: ({PosicaoX:F0},{PosicaoY:F0})");
    }
}
