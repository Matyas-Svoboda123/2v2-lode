        using System;
        using _2v2_lode;

        MainMenu();
        static void MainMenu()
        {
            int volba = -1;

            while (volba != 0)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("          LODĚ 2v2");
                Console.WriteLine("=================================");
                Console.WriteLine("1) Nová hra");
                Console.WriteLine("2) Pravidla");
                Console.WriteLine("3) Konec");
                Console.WriteLine("=================================");
                Console.Write("Zadej volbu: ");

                string vstup = Console.ReadLine();
                int.TryParse(vstup, out volba);

                switch (volba)
                {
                    case 1:
                        NovaHra();
                        break;
                    case 2:
                        Pravidla();
                        break;
                    case 3:
                        Console.WriteLine("Ukončuji hru...");
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zkus to znovu.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void NovaHra()
{
    Console.Clear();
    Console.WriteLine("=== NOVÁ HRA 2v2 ===");
    Console.WriteLine("Zadejte jména hráčů:");

    // --- Tým 1 ---
    Console.Write("Tým 1 - Hráč 1: ");
    string t1p1 = Console.ReadLine();
    Console.WriteLine("Tady je tvé hrací pole, naplň si ho");
    Console.ReadKey();
    HraciPole t1p1_pole = new HraciPole();
    t1p1_pole.NaplnPole();

    Console.Write("Tým 1 - Hráč 2: ");
    string t1p2 = Console.ReadLine();
    Console.WriteLine("Tady je tvé hrací pole, naplň si ho");
    Console.ReadKey();
    HraciPole t1p2_pole = new HraciPole();
    t1p2_pole.NaplnPole();

    // --- Tým 2 ---
    Console.Write("Tým 2 - Hráč 1: ");
    string t2p1 = Console.ReadLine();
    Console.WriteLine("Tady je tvé hrací pole, naplň si ho");
    Console.ReadKey();
    HraciPole t2p1_pole = new HraciPole();
    t2p1_pole.NaplnPole();

    Console.Write("Tým 2 - Hráč 2: ");
    string t2p2 = Console.ReadLine();
    Console.WriteLine("Tady je tvé hrací pole, naplň si ho");
    Console.ReadKey();
    HraciPole t2p2_pole = new HraciPole();
    t2p2_pole.NaplnPole();


    Console.Clear();
    Console.WriteLine("\nTýmy připraveny!");
    Console.WriteLine($"{t1p1} a {t1p2}  VS  {t2p1} a {t2p2}");
    Console.WriteLine("\nStiskni libovolnou klávesu pro start hry...");
    Console.ReadKey();

    // ====== HERNÍ SMYČKA ======
    int tah = 0;

    while (true)
    {
        Console.Clear();
        string aktivniJmeno = "";
        HraciPole aktivniPole = null;

        // určení hráče podle tahu
        switch (tah % 4)
        {
            case 0:
                aktivniJmeno = t1p1;
                aktivniPole = t1p1_pole;
                break;
            case 1:
                aktivniJmeno = t2p1;
                aktivniPole = t2p1_pole;
                break;
            case 2:
                aktivniJmeno = t1p2;
                aktivniPole = t1p2_pole;
                break;
            case 3:
                aktivniJmeno = t2p2;
                aktivniPole = t2p2_pole;
                break;
        }

        Console.WriteLine($"=== Na tahu je hráč: {aktivniJmeno} ===");

        // Výběr cíle
        HraciPole cil = null;
        string cilJmeno = "";

        if (aktivniJmeno == t1p1 || aktivniJmeno == t1p2)
        {
            Console.WriteLine("Vyber hráče z Týmu 2, na kterého chceš střílet:");
            Console.WriteLine("1) " + t2p1 + (t2p1_pole.ZbyleLode == 0 ? " (mrtvý)" : ""));
            Console.WriteLine("2) " + t2p2 + (t2p2_pole.ZbyleLode == 0 ? " (mrtvý)" : ""));

            int volba = 0;
            while (volba != 1 && volba != 2)
                int.TryParse(Console.ReadLine(), out volba);

            if (volba == 1) { cil = t2p1_pole; cilJmeno = t2p1; }
            else { cil = t2p2_pole; cilJmeno = t2p2; }
        }
        else
        {
            Console.WriteLine("Vyber hráče z Týmu 1, na kterého chceš střílet:");
            Console.WriteLine("1) " + t1p1 + (t1p1_pole.ZbyleLode == 0 ? " (mrtvý)" : ""));
            Console.WriteLine("2) " + t1p2 + (t1p2_pole.ZbyleLode == 0 ? " (mrtvý)" : ""));

            int volba = 0;
            while (volba != 1 && volba != 2)
                int.TryParse(Console.ReadLine(), out volba);

            if (volba == 1) { cil = t1p1_pole; cilJmeno = t1p1; }
            else { cil = t1p2_pole; cilJmeno = t1p2; }
        }

        if (cil.ZbyleLode == 0)
        {
            Console.WriteLine("Tento hráč už nemá lodě! Vyber někoho jiného.");
            Console.ReadKey();
            continue;
        }

        Console.WriteLine($"\n{aktivniJmeno} střílí na: {cilJmeno}");
        Console.WriteLine($"\nZobrazuji pole hráče {cilJmeno}:");
        cil.VypisPole(true);   // ukáže pole soupeře, ale bez lodí
        Console.WriteLine("\nZadej souřadnice, kam chceš střílet:");
        bool platnyTah = cil.Strilej();

        // Zkontroluj, zda některý tým neprohrál
        if (t1p1_pole.ZbyleLode == 0 && t1p2_pole.ZbyleLode == 0)
        {
            Console.WriteLine("\n=== Tým 2 VYHRÁVÁ! ===");
            Console.ReadKey();
            return;
        }
        if (t2p1_pole.ZbyleLode == 0 && t2p2_pole.ZbyleLode == 0)
        {
            Console.WriteLine("\n=== Tým 1 VYHRÁVÁ! ===");
            Console.ReadKey();
            return;
        }

        if (platnyTah)
            tah++; // pouze platný tah se počítá
    }
}


        static void Pravidla()
        {
            Console.Clear();
            Console.WriteLine("=== PRAVIDLA ===");
            Console.WriteLine("Každý hráč má svou hrací plochu.");
            Console.WriteLine("Hráči se střídají v hádání pozic nepřátelských lodí.");
            Console.WriteLine("Když hráč nemá spolu hráče tak bude hrát za něj.");
            Console.WriteLine("Cíl: potopit všechny lodě soupeře.");
            Console.WriteLine("\nStiskni libovolnou klávesu pro návrat...");
            Console.ReadKey();
        }
        

       