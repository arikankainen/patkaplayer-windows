# Pätkä Player

Windows-ohjelma audioklippien soittamiseen. Klippien tulee olla `MP3`-muodossa, ja sijaita yhdessä pääkansiossa, esim. `Pätkät`. Tuon kansion pitää sisältää alikansioita, joihin itse klipit sijoitetaan.

![Pätkä Player](/docs/main.png)

## Käyttö

Aluksi täytyy valita kansio jonka alikansioissa klipit ovat. Kansio valitaan asetuksista (yläkulman ratasikoni) valitsemalla `Select folder`. Kansiovalinnan jälkeen alikansiot näkyvät ohjelman vasemman laidan kansiolistassa. Kansiota klikkaamalla sen sisältämät klipit näytetään keskimmäisessä tiedostolistassa. Kansiolistan ylimpänä vaihtoehtona on `All folder`-valinta, jolla kaikkien kansioiden sisältö saadaan tiedostolistaan kerralla. Klippiä klikkaamalla se soitetaan, ja edistyminen näkyy työkalurivin keskellä olevassa edistymispalkissa. Klippiä voi kelata klikkaamalla edistymispalkkia eri kohdista. Palkin vasemmalla puolella oleva `Refresh`-valinnalla voidaan valita kuinka usein edistymispalkkia päivitetään. Liian nopea päivitys heikkotehoisella koneella saa äänen pätkimään.

Ikkunan oikealta puolelta löytyy soittolista, johon voidaan hiirellä raahata tiedostolaatikosta valittu klippi/valitut klipit. Myös kansiolistalta voidaan raahata kokonainen kansio. Soittolistan valitut klipit voidaan poistaa listalta raahaamalla ne tiedostolistan päälle. Soittolistan klippien järjestystä voi myös muuttaa hiirellä. Soittolistan tyhjennykseen, tallennukseen ja lataamiseen löytyy työkaluriviltä omat painikkeensa. Ohjelmaa suljettaessa nykyinen soittolista tallennetaan `autosave.lst`-tiedostoon, ja ladataan sieltä automaattisesti käyttöön seuraavassa käynnistyksessä.

Yksittäisiä klippejä voidaan raahata myös ikkunan oikean laidan pikanappeihin, joita löytyy 15 kappaletta. Asetuksista kullekkin napille voidaan haluttaessa valita pikanäppäin, jolla voidaan soittaa kyseinen klippi vaikka ohjelma ei olisi aktiivisena. Pikanappien tyhjennys onnistuu ohjelman asetuksista.

Työkalurivillä on vasemmassa laidassa `Play random`, `Stop` ja `Replay` -napit, joilla voidaan soittaa satunnainen klippi, pysäyttää se, tai soittaa se uudelleen. Työkalurivin oikealla puolella on valinnat `Folders`, `Files` ja `Playlist`, joilla valitaan mistä listasta satunnainen klippi soitetaan. Kunkin listan alapuolella on suodattimet, joilla listan soitettavaa sisältöä voidaan väliaikaisesti suodattaa.

Tilarivillä on kaksi ajastinta, joita hiiren vasemmalla klikkaamalla saadaan ajastin päälle/pois, ja hiiren oikealla päästään suoraan asetuksiin muokkaamaan ajastimen aikaa. Ajastimella voidaan siis soittaa satunnainen klippi valitun minimiajan ja maksimiajan väliltä. Molemmat ajastimet eivät voi olla samaan aikaan päällä.

## Asetukset

![Asetukset](/docs/settings.png)

`Folders`-välilehdellä määritellään pääkansio, jonka alikansioissa klipit sijaitsee. Sen alla voidaan määritellä tai tyhjentää jokaisen viidentoista pikanapin klippi.

`Settings`-välilehdellä voidaan valita tallennetaanko klippien toistohistoria lokitiedostoon ja muistetaanko nykyisen päivän toistomäärä vaikka ohjelma välissä suljettaisiin. Voidaan myös valita, näytetäänkö ohjelman kuvake aina tehtäväpalkin ilmoitusalueella. Silloin kun kuvake näytetään, on mahdollista näyttää ilmoitus kun klippi soitetaan tai kun ajastin laitetaan päälle/pois. Myös ohjelman ikkunan läpinäkyvyyttä voidaan säätää. Latenssivalinta on sama joka löytyy ohjelman työkaluriviltä nimellä `Refresh`.

`Timers`-välilehdellä säädetään ajastimien minimi ja maksimiajat. Jos esimerkiksi minimiajaksi laitetaan 5 minuuttia, ja maksimiajaksi 10 minuuttia, arvotaan satunnainen aika joka on noiden kahden ajan välillä ja soitetaan klippi kun tuo aika on kulunut. Sen jälkeen arvotaan taas uusi aika. Ajastin aktivoidaan pääikkunan tilariviltä klikkaamalla ajastinta jolloin päälle mennessään se muuttuu punaiseksi.

`Hotkeys`-välilehdellä voidaan eri toiminnoille määritellä pikanäppäin. Esimerkiksi satunnaisen klipin soittoon voidaan määritellä vaikkapa `Alt-X`, jolloin satunnaisen klipin voi soittaa kyseistä näppäinyhdistelmää painamalla. Kun pikanäppäimen määrittelyikkunasta laittaa ruksin `Global hotkey`, ei Pätkä Playerin tarvitse olla aktiivisena ja pikanäppäin toimii silti. Ikkunan alareunasta voidaan valita, halutaanko varoitus jos joku määritellyistä pikanäppäimistä on jo varattu toisen ohjelman käyttöön, eikä siis toimi Pätkä Playerin kanssa.

## Lataus

En ota mitään vastuuta ohjelman mahdollisesti aiheuttamista vahingoista; kukin käyttää ohjelmaa omalla vastuullaan.

**[Lataa uusin versio](https://github.com/arikankainen/patkaplayer-windows/releases)**
