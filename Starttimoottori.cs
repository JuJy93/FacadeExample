namespace FacadeExample;

public class Starttimoottori // Alijärjestelmä, joka vastaa auton starttimoottorin pyörittämisestä
{
    public void Pyori(int ms)
    {
        Console.WriteLine($"  → Starttimoottori pyörii {ms}ms...");
    }
}
