# Název projektu: Lodě 2v2

## Autoři
- Matěj Bartoš
- Matyáš Svoboda

## Popis hry
Lodě 2v2 je konzolová tahová hra inspirovaná klasickými „Battleships“.  
Hrají proti sobě **dva týmy po dvou hráčích**. Každý hráč má vlastní hrací pole,
na které rozmisťuje své lodě. Hráči se následně **střídají po pořadí**  
(T1P1 → T2P1 → T1P2 → T2P2 → …) a střílí na pole hráčů opačného týmu.

Hra končí, jakmile **jeden tým přijde o obě hrací pole** (tj. oběma hráčům dojdou lodě).

---

## Pravidla hry
- Každý hráč má vlastní **10×10 pole**.
- Každý hráč umístí tyto lodě:
    - 4× loď velikosti 1
    - 3× loď velikosti 2
    - 2× loď velikosti 3
    - 1× loď velikosti 4
- Lodě se mohou pokládat **vertikálně** nebo **horizontálně**.
- Lodě nesmí být mimo pole ani se překrývat.
- Při střelbě hráč:
  - vybere hráče soupeřova týmu, na kterého chce střílet,
  - zobrazí se mu **skryté pole soupeře** (lodě nejsou vidět),
  - zadá souřadnice výstřelu.
- Zásah se označí **p**, minula **m**.
- Každý hráč má vlastní sadu lodí (nejsou sdílené v týmu).
- Tým prohrává, když **oba jeho hráči mají zničeny všechny lodě**.

---

## Ovládání
Hra se ovládá pomocí textových vstupů do konzole.

### Při pokládání lodí:
- Souřadnice se zadávají jako čísla X a Y.
- Směr:
    - `h` – horizontálně
    - `v` – vertikálně
- Potvrzení volby – Enter

### Při hře:
- Vyber hráče, na kterého chceš střílet (1 nebo 2)
- Zadej X a Y souřadnici výstřelu
- Pole soupeře se zobrazí v režimu, kde **nejsou vidět jeho lodě**


## Struktura programu

### `Program.cs`
Obsahuje:
- Menu (Start hry, Pravidla, Konec)
- Hlavní herní smyčku
- Řízení střídání hráčů
- Logiku vybírání soupeře
- Kontrolu vítězství týmu

### `HraciPole.cs`
Třída reprezentující jedno hrací pole hráče.
Obsahuje:
- 10×10 pole znaků (`v` voda, `l` loď, `m` minela, `p` zásah)
- `NaplnPole()` — umisťování lodí hráčem
- `VypisPole(bool skryte)` — výpis pole, možnost skrýt lodě
- `MuzePolozit()` — kontrola pravidel pro umístění lodě
- `PolozeniLodi()` — umístění lodě na pole
- `Strilej()` — zpracování střelby na dané pole
- Počítání zbývajících lodí
## Spolupráce
_Matěj pracoval na menu a pokládání lodí. Matyáš pracoval na střelbě. Na vypisování pole jsem spolupracovali._

## Známé problémy / omezení
_O žádných nevíme a doufáme, že nejsou!_
