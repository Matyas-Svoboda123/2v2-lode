
using System;
using System.Runtime.CompilerServices;

namespace _2v2_lode;

    public class HraciPole
    {
        public char[,] pole = new char[10, 10];
        public int ZbyleLode = 20;

        public void VypisPole(bool skryte = true)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    char c = pole[i, j];
                    char zobraz = c;

                    if (skryte)
                    {
                        // Nepřítel nesmí vidět lodě
                        if (c == 'l')
                            zobraz = 'v';  // nebo '?'
                    }

                    switch (zobraz)
                    {
                        case 'v':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case 'p':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        case 'm':
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.Write(zobraz + " ");
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void NaplnPole()
        {
            // Naplní celé pole vodou
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = 'v'; // voda
                }
            }

            int l1 = 4; // lodě o velikosti 1
            int l2 = 3; // lodě o velikosti 2
            int l3 = 2; // lodě o velikosti 3
            int l4 = 1; // lodě o velikosti 4

            string lod;
            int x, y;
            char smer; // h = horizontálně, v = vertikálně

            while (l1 > 0 || l2 > 0 || l3 > 0 || l4 > 0)
            {
                Console.Clear();
                VypisPole();

                Console.WriteLine("\nJakou loď chceš položit? (1–4)");
                Console.WriteLine($"Loď(1): {l1}, Loď(2): {l2}, Loď(3): {l3}, Loď(4): {l4}");

                // --- výběr platné lodě ---
                do
                {
                    lod = Console.ReadLine();
                } while (lod != "1" && lod != "2" && lod != "3" && lod != "4");

                int velikost = int.Parse(lod);

                // Zkontroluj, jestli má hráč tuto loď ještě k dispozici
                if ((velikost == 1 && l1 == 0) ||
                    (velikost == 2 && l2 == 0) ||
                    (velikost == 3 && l3 == 0) ||
                    (velikost == 4 && l4 == 0))
                {
                    Console.WriteLine("Tuto loď už nemáš! Zkus jinou.");
                    Console.ReadKey();
                    continue;
                }

                // --- Zadej pozici a směr ---
                Console.Write("Zadej X souřadnici (0 - " + (pole.GetLength(0) - 1) + "): ");
                x = int.Parse(Console.ReadLine());

                Console.Write("Zadej Y souřadnici (0 - " + (pole.GetLength(1) - 1) + "): ");
                y = int.Parse(Console.ReadLine());

                if (velikost > 1)
                {
                    Console.Write("Zadej směr (h = horizontálně, v = vertikálně): ");
                    smer = char.Parse(Console.ReadLine());
                }
                else
                {
                    smer = 'h'; // pro velikost 1 směr neřešíme
                }

                // --- Ověření, zda může být loď položena ---
                if (!MuzePolozit(x, y, velikost, smer))
                {
                    Console.WriteLine("Nelze umístit loď – mimo pole nebo koliduje s jinou lodí!");
                    Console.ReadKey();
                    continue;
                }

                // --- Umístění lodi ---
                PolozeniLodi(x, y, velikost, smer);
                Console.WriteLine("Loď položena!");

                // --- Snížení počtu dostupných lodí ---
                switch (velikost)
                {
                    case 1: l1--; break;
                    case 2: l2--; break;
                    case 3: l3--; break;
                    case 4: l4--; break;
                }

                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Všechny lodě byly úspěšně položeny!");
            VypisPole();
        }

        private bool MuzePolozit(int x, int y, int velikost, char smer)
        {
            if (smer == 'v')
            {
                if (x + velikost > pole.GetLength(0)) return false;
                for (int i = 0; i < velikost; i++)
                {
                    if (pole[x + i, y] != 'v') return false;
                }
            }
            else // vertikálně
            {
                if (y + velikost > pole.GetLength(1)) return false;
                for (int i = 0; i < velikost; i++)
                {
                    if (pole[x, y + i] != 'v') return false;
                }
            }

            return true;
        }

        private void PolozeniLodi(int x, int y, int velikost, char smer)
        {
            if (smer == 'v')
            {
                for (int i = 0; i < velikost; i++)
                {
                    pole[x + i, y] = 'l';
                }
            }
            else
            {
                for (int i = 0; i < velikost; i++)
                {
                    pole[x, y + i] = 'l';
                }
            }
        }


        public bool Strilej()
        {
            // Upozornění: int.Parse bez try/catch může způsobit pád, pokud uživatel zadá text
            Console.Write("Zadej X souřadnici (0 - " + (pole.GetLength(0) - 1) + "): ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Zadej Y souřadnici (0 - " + (pole.GetLength(1) - 1) + "): ");
            int y = int.Parse(Console.ReadLine());

            // Kontrola mezí (bez return false v if)
            bool vMezich = true;
            if (x < 0) vMezich = false;
            if (x >= pole.GetLength(0)) vMezich = false;
            if (y < 0) vMezich = false;
            if (y >= pole.GetLength(1)) vMezich = false;


            if (!vMezich)
            {
                Console.WriteLine("\nStřela je mimo hrací pole! Zkus to znovu.");
                Console.ReadKey();
                return false; // Nepočítá se jako platný tah
            }

            char cil = pole[x, y];
            if (cil == 'v') // Voda - Miss
            {
                pole[x, y] = 'm';
                Console.WriteLine("\n[VEDLE] Střela minula cíl (Voda).");
            }
            else if (cil == 'l') // Loď - Hit
            {
                pole[x, y] = 'p';
                ZbyleLode--; // Upraveno: Používá ZbyleLode přímo místo this.ZbyleLode
                Console.WriteLine("\n[ZÁSAH] Trefil jsi loď!");
            }
            else // Už trefeno nebo minuto
            {
                Console.WriteLine("\n[UPOZORNĚNÍ] Už jsi střílel na toto místo. Zkus to znovu.");
                Console.ReadKey();
                return false; // Nepočítá se jako platný tah
            }

            Console.WriteLine("\nStav pole po střele:");
            VypisPole();

            Console.WriteLine("\nStiskni libovolnou klávesu pro pokračování...");
            Console.ReadKey();
            return true; // Platný tah
        }
    }
