namespace FacadeExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ILMAN FACADE-MALLIA: (5 objektia, 6 kutsua)\n");

        // Luodaan erilliset olio jokaiselle alijärjestelmälle ja kutsutaan niiden metodeja oikeassa järjestyksessä
        var sytytys = new Sytytys();                
        var jaahdytys = new Jaahdytysjarjestelma();
        var pumppu = new PolttoainePumppu();
        var startti = new Starttimoottori();
        var moottori = new Moottori();

        // Käskyjen suorittaminen suoraan ilman Facadea vaatii, 
        // että asiakas tuntee kaikkien alijärjestelmien rajapinnat ja osaa kutsua niitä oikeassa järjestyksessä
        Console.WriteLine("1. Käännetään avainta");
        sytytys.KytkeVirta();                           //Käännetään avainta

        Console.WriteLine("2. Mitataan jäähdytysnesteen taso");
        jaahdytys.TarkistaJaahdytysnesteenTaso();       //Tarkistetaan jäähdytysnesteen taso ja käynnistetään pumppu

        Console.WriteLine("3. Käynnistetään jäähdytyspumppu");
        jaahdytys.KaynnistaPumppu();                    //Jäähdytyspumppu on syytä käynnistää ennen moottoria, muuten se saattaa ylikuumentua


        Console.WriteLine("4. Mitataan ja syötetään polttoainetta");
        pumppu.Pumppaa(50);                             //Pumppaa polttoainetta jonka määrän käyttäjä on syöttänyt

        Console.WriteLine("5. Ajoitetaan starttimoottori pyörimään tasan sekunti");
        startti.Pyori(1000);                            //Pyöritetään starttimoottoria käyttäjän määräämän ajan

        Console.WriteLine("6. Käynnistetään moottori ja toivotaan, että muistimme tehdä kaikki edelliset tehtävät oikeassa järjestyksessä...");
        moottori.Kaynnista();                           //Käynnistetään moottori, joka vaatii, että kaikki edelliset
                                                        //toimenpiteet on suoritettu onnistuneesti oikeassa järjestyksessä.
        
        Console.WriteLine("\n---\n");
        Console.WriteLine("FACADE-MALLILLA: (1 objekti, 1 kutsu)\n");

        // Facade-mallilla asiakas tarvitsee vain yhden olion, joka tarjoaa yksinkertaisen rajapinnan monimutkaiseen järjestelmään
        var auto = new AutoFacade();                    // AutoFacade hoitaa kaiken monimutkaisuuden sisäisesti
        auto.KaynnistaAuto();                           // Asiakkaan tarvitsee vain kutsua yhtä metodia, 
                                                        // joka hoitaa kaikki tarvittavat toimenpiteet oikeassa järjestyksessä.
    }
}
