using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Sodacrate my_sodacrate = new Sodacrate(); // Skapar ett objekt av klassen Sodacrate
            my_sodacrate.run(); // Startar programmet

            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey(true);

        }
    }

    class Sodacrate //Definierar klassen sodacrate
    {
        string[] drinks = new string[25]; // Skapar en vektor som representerar de 25 positionerna i läskbacken.
        int amount = 0; // Antalet flaskor i backen

        public void run()
        {
            int temp = 0; // Heltals variabel för nummret av det valda alternativet
            string input = ""; // Sträng variabel för användarens inmatning
            do
            { // Skriver ut de olika alternativen som berättar vad du kan göra
                Console.WriteLine("Välj alternativ");
                Console.WriteLine("1. Lägg till");
                Console.WriteLine("2. Skriv ut");
                Console.WriteLine("3. Beräkna totala värdet");
                Console.WriteLine("4. Sök efter en flaska");
                Console.WriteLine("5. Sortera");
                Console.WriteLine("0. Avsluta programmet");

                bool loop = true; //Try-Catch loop för att kontrollera att användaren matar in ett heltal
                do
                {
                    input = Console.ReadLine();
                    try
                    {
                        int input_is_int = int.Parse(input); // Input kan konverteras till heltal
                        loop = false; //bryter loopen
                    }
                    catch
                    {
                        Console.WriteLine("Felaktig inmatning. Du måste välja ett av talen i menyn.");
                    }
                } while (loop);

                temp = int.Parse(input); //Registrerar användarens inmatning som valt alternativ

                switch (temp) // Switch Case för alternativen i programmet. Varje case anropar på en metod beskriven nedan.
                {
                    case 1:
                        Add(); 
                        break;
                    case 2:
                        Print();
                        break;
                    case 3:
                        Sum();
                        break;
                    case 4:
                        Search();
                        break;
                    case 5:
                        Sort();
                        break;
                    case 0:
                        Console.WriteLine("Programmet avslutas");
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning. Du måste välja ett av talen i menyn.");
                        break;
                }
            } while (temp != 0);


        }

        public void Add() // Låter användaren lägga till önskad flaska till läskbacken, om backen inte är full, då får användaren ange vilken position de vill ersätta.
        {
            Console.WriteLine("Lägg till en läsk");
            
            string input = Console.ReadLine(); // Användaren anger namnet på sin läsk

            if (amount < 25) // Kontrollerar om backen är full
            {
                drinks[amount] = input; // Placerar användarens läsk i nästa lediga position
                amount = amount + 1; // Ökar antalet flaskor med 1
            }
            else
            {
                Console.WriteLine("Det finns inte tillräckligt med plats. Välj den position du vill ersätta");
                int position = int.Parse(Console.ReadLine());
                drinks[position] = input; // Ersätter läsken i angiven position
            }

        }

        public void Print() // Skriver ut läskbackens innehåll
        {
            for (int i = 0; i < amount; i++)// Loopar igenom vektorn för de positioner som innehåller en läsk och skriver ut namnet
                Console.WriteLine(drinks[i]);
        }

        public void Sum() // Räknar ut det totala priset på läskbacken
        {
            int price = 5; // 5 kr per flaska
            int sum = amount * price; // antalet flaskor * 5 kr
            Console.WriteLine("Läskbacken kostar " + sum + " kr");

        }

        public void Search() // Söker en läsk i läskbacken
        {
            int i = 0;
            Console.WriteLine("Vilken läsk letar du efter?");
            string new_name = Console.ReadLine();
            for (i = 0; i < drinks.Length; i++) //Går igenom varje position i läskbacken
            {
                if (drinks[i] == new_name) // Om namnet på elementet matchar sökordet skriver programmet ut positionen på läsken
                { 
                    Console.WriteLine("Det finns " + new_name + " i position " + i);
                    break;
                }
                else if (i == drinks.Length - 1) // Om loopen har gått igenom hela vektorn utan att hitta någon flaska skrivs ett meddelande ut
                    Console.WriteLine("Det finns ingen" + new_name);
             }
        }

        public void Sort() // Sorterar läskbackens innehåll efter namnets längd med hjälp av bubble sort.
        {
            int max = amount - 1; //Räknar ut maximala antalet jämförelser i en loop
            for (int i = 0; i < max; i++) // Loopar igenom tills dess att varje position har bestämts.
            {
                int nrLeft = max - i; // Räknar ut hur många jämförelser som måste göras. -i gör att vi hoppar överjämförelser vid positioner som vi vet redan är bestämda
                for (int j = 0; j < nrLeft; j++) // Går igenom varje position som är kvar att jämföras
                {
                    if (drinks[j].Length > drinks[j + 1].Length) // Kollar om längden på namnet vid en given position är längre än efterföljande position
                    {
                        string temp = drinks[j]; // tillfällig variabel för att spara namnet på den första läsken
                        drinks[j] = drinks[j + 1]; // Ersätter den första läsken med den efterföljande
                        drinks[j + 1] = temp; // Ersätter den efterföljande läsken med den första
                    }
                }
            }
            Console.WriteLine("Läskbacken är nu sorterad:");
            Print(); // Anropar Print metoden för att skriva ut innehållet i den sorterade läskbacken

        }


    }


    
}
