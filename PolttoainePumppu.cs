namespace FacadeExample;

public class PolttoainePumppu // Alijärjestelmä, joka vastaa polttoaineen pumppaamisesta moottoriin
{
    public void Pumppaa(int maara)
    {
        Console.WriteLine($"  → Polttoainetta syötetty {maara} ml");
    }
}
