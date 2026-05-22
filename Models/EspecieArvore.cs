namespace FlyweightForest.Models;

public class EspecieArvore
{
    public string Nome { get; }
    public string Cor { get; }
    public float AlturaMinima { get; }
    public float AlturaMaxima { get; }
    public float CircunfMinima { get; }
    public float CircunfMaxima { get; }
    public int IdadeMinima { get; }
    public int IdadeMaxima { get; }

    public EspecieArvore(string nome, string cor,
                         float altMin, float altMax,
                         float cirMin, float cirMax,
                         int idadeMin, int idadeMax)
    {
        Nome = nome;
        Cor = cor;
        AlturaMinima = altMin;
        AlturaMaxima = altMax;
        CircunfMinima = cirMin;
        CircunfMaxima = cirMax;
        IdadeMinima = idadeMin;
        IdadeMaxima = idadeMax;
    }
}
