namespace FacadeExample;

public class Jaahdytysjarjestelma // Alijärjestelmä, joka vastaa auton jäähdytyksestä
{
    public void TarkistaJaahdytysnesteenTaso()
    {
        Console.WriteLine("  → Jäähdytysnesteen taso OK");
    }

    public void KaynnistaPumppu()
    {
        Console.WriteLine("  → Jäähdytyspumppu käynnistyy");
    }
}
