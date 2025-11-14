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

            Console.Write("Tým 1 - Hráč 1: ");
            string t1p1 = Console.ReadLine();
            char[,] t1a1=new char[10, 10];
            HraciPole t1h1 = new HraciPole(t1a1);
            t1h1.NaplnPole();
            Console.Write("Tým 1 - Hráč 2: ");
                
            string t1p2 = Console.ReadLine();

            Console.Write("Tým 2 - Hráč 1: ");
            string t2p1 = Console.ReadLine();

            Console.Write("Tým 2 - Hráč 2: ");
            string t2p2 = Console.ReadLine();
            
            Console.WriteLine($"\nTýmy připraveny!");
            Console.WriteLine($"{t1p1} a {t1p2}  VS  {t2p1} a {t2p2}");
            Console.WriteLine("\nStiskni libovolnou klávesu pro návrat do menu...");
            Console.ReadKey();
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
        

       