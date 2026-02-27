namespace FacadeExample;

public class AutoFacade                                     // Facade-luokka
{
    private Sytytys _sytytys = new();                       // AutoFacade sisältää viitteet kaikkiin 
    private Jaahdytysjarjestelma _jaahdytys = new();        // alijärjestelmiin, joita tarvitaan auton käynnistämiseen, 
    private PolttoainePumppu _pumppu = new();               // mutta asiakkaan ei tarvitse tietää näistä olioista mitään, 
   private Starttimoottori _startti = new();                // koska AutoFacade hoitaa kaiken sisäisesti.
    private Moottori _moottori = new();                     // Se katsoo, että kaikki tarvittavat toimenpiteet 
                                                            // suoritetaan oikeassa järjestyksessä.
    public void KaynnistaAuto()                             // Yksittäinen metodi piilottaa alijärjestelmien kutsut
    {
        Console.WriteLine("1. Käännetään avainta...");
        _sytytys.KytkeVirta();
        _jaahdytys.TarkistaJaahdytysnesteenTaso();
        _jaahdytys.KaynnistaPumppu();
        _pumppu.Pumppaa(50);
        _startti.Pyori(1000);
        _moottori.Kaynnista();
        Console.WriteLine("2. Auto on käynnissä!");
    }
}
