# Facade-suunnittelumalli - AutoFacade Esimerkki

## Yleiskuvaus
Tämä esimerkki näyttää kuinka **Facade-suunnittelumalli** yksinkertaistaa monimutkaisen järjestelmän käyttöä. Esimerkissä käytetään auton käynnistämistä: järjestelmä koostuu useista toisiaan riippuvaisista alijärjestelmistä, jotka on aktivoitava oikeassa järjestyksessä.

Ilman Facadea asiakas joutuu hallinnoimaan kaikkia alijärjestelmiä manuaalisesti. Facaden kanssa asiakas kutsuu vain yhtä metodia.

## Ongelma ilman Facadea
Asiakaskoodi joutuu:
- Luomaan 5 eri objektia (Sytytys, Jaahdytysjarjestelma, PolttoainePumppu, Starttimoottori, Moottori)
- Kutsumaan 6 metodia oikeassa järjestyksessä
- Tietämään, minkä järjestelmän mitä metodia kutsua ja milloin
- Päivittämään koodia useissa paikoissa, jos järjestys tai logiikka muuttyy

## Ratkaisu: AutoFacade
Facade-luokka (`AutoFacade`):
- Kapseloi kaikki alijärjestelmät sisälleen
- Hallitsee oikean suoritusjärjestyksen
- Tarjoaa yhden yksinkertaisen metodin: `KaynnistaAuto()`
- Asiakka kutsuu vain yhtä metodia - loput tapahtuu automaattisesti

## Rakenne
```
FacadeExample/
├── Program.cs                  # Pääohjelma, demonstroi ilman ja kanssa Facadea
├── AutoFacade.cs              # 🎭 Facade-luokka - tämä on ratkaisun ydin
├── Sytytys.cs                 # Alijärjestelmä 1: Virran kytkeminen
├── Jaahdytysjarjestelma.cs    # Alijärjestelmä 2: Jäähdytyksen hallinta
├── PolttoainePumppu.cs        # Alijärjestelmä 3: Polttoaineen syöttö
├── Starttimoottori.cs         # Alijärjestelmä 4: Starttimoottori
├── Moottori.cs                # Alijärjestelmä 5: Päämoottori
├── FacadeExample.csproj       # Projektitiedosto
└── README.md                  # Tämä tiedosto
```

## Alijärjestelmät

| Luokka | Vastuu | Metodit |
|--------|--------|---------|
| **Sytytys** | Virran kytkeminen | `KytkeVirta()` |
| **Jaahdytysjarjestelma** | Jäähdytyksen hallinta | `TarkistaJaahdytysnesteenTaso()`, `KaynnistaPumppu()` |
| **PolttoainePumppu** | Polttoaineen syöttö | `Pumppaa(int määrä)` |
| **Starttimoottori** | Starttaus | `Pyori(int ms)` |
| **Moottori** | Päämoottori | `Kaynnista()` |

## Ajon järjestys
Moottori käynnistyy, kun nämä vaiheet suoritetaan **tässä järjestyksessä**:
1. ✓ Virta kytketään (Sytytys)
2. ✓ Jäähdytysnesteen taso tarkistetaan (Jaahdytysjarjestelma)
3. ✓ Jäähdytyspumppu käynnistetään (Jaahdytysjarjestelma)
4. ✓ Polttoaine pumpataan (PolttoainePumppu)
5. ✓ Starttimoottori pyörii (Starttimoottori)
6. ✓ Päämoottori käynnistyy (Moottori)

## Käyttö

### Suoritus
```bash
cd FacadeExample
dotnet run
```

### Tuloste

Ohjelma demonstroi kahta eri lähestymistapaa:

**ILMAN FACADE-MALLIA (5 objektia, 6 kutsua):**
```
ILMAN FACADE-MALLIA: (5 objektia, 6 kutsua)

1. Käännetään avainta
   Virta kytketty
2. Mitataan jäähdytysnesteen taso
   Jäähdytysnesteen taso OK
3. Käynnistetään jäähdytyspumppu
   Jäähdytyspumppu käynnistyy
4. Mitataan ja syötetään polttoainetta
   Polttoainetta 50ml
5. Ajoitetaan starttimoottori pyörimään tasan sekunti
   Starttimoottori
6. Käynnistetään moottori...
   MOOTTORI KÄYNNISTYY: VRUUM!
```
- Asiakas luo 5 erillistä objektia
- Asiakas kutsuu kuutta metodia oikeassa järjestyksessä
- Monimutkaista, virheille altista, vaikea ylläpitää

**FACADE-MALLILLA (1 objekti, 1 kutsu):**
```
FACADE-MALLILLA: (1 objekti, 1 kutsu)

✓ Auto käynnistyy...
  Virta kytketty
  Jäähdytysnesteen taso OK
  Jäähdytyspumppu käynnistyy
  Polttoainetta 50ml
  Starttimoottori
  MOOTTORI KÄYNNISTYY: VRUUM!
✓ Auto on käyttövalmis!
```
- Asiakas luo vain AutoFacade-objektin
- Asiakas kutsuu vain yhtä metodia: `KaynnistaAuto()`
- Yksinkertaista, turvallista, helppo ylläpitää

## Edut ✅
- **Yksinkertainen asiakasrajapinta** - Vain yksi metodikutsu  
- **Vähemmän riippuvuuksia** - Asiakas ei tarvitse tietää alijärjestelmistä  
- **Helpompi ylläpitää** - Muutokset VAIN Facadessa, ei asiakaskoodissa  
- **Testattavuus** - Voi testata Facadea yksikkötestillä  
- **Koodi on ymmärrettävää** - Selkeä intent, mitä koodi tekee

## Haitat ⚠️
- **Liian yksinkertaistettu rajapinta** - Advanced-käyttäjä ei voi kutsua luokkia suoraan  
- **Ylimääräinen kerros** - Lisää kompleksiutta yksinkertaisissa tapauksissa  
- **Muisti** - Facade pitää kaikki alijärjestelmät muistissa kokoajan
