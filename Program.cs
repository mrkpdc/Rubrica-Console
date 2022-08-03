using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica___Console
{
    internal class Program
    {
        /* creare una rubrica:
         *      - aggiunta contatti
         *      - consultazione di tutti i contatti
         *      - ricerca contatti
         *      - opzionale: cancellazione contatti
         *      - opzionale per masochisti: modifica contatti
         *      - mettere in ordine alfabetico quando si aggiunge un contatto (inserire il contatto nel posto giusto)
         *      https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist.add?view=net-6.0
         */

        static void Main(string[] args)
        {
            // Istanzio la rubrica
            Rubrica rubrica = new Rubrica();
            rubrica.IntroRubrica();
            Console.WriteLine("Premi un tasto qualsiasi per iniziare!");
            Console.ReadKey();

            bool accessoRubrica = true;
            while (accessoRubrica == true)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("1) Stampa contatti");
                Console.WriteLine("2) Aggiungi contatto");
                Console.WriteLine("3) Ricerca contatti");
                Console.WriteLine("4) Genera contatti casuali");
                Console.WriteLine("5) Elimina contatto");
                Console.WriteLine("6) Modifica contatto");
                Console.WriteLine("7) Esci");
                Console.WriteLine();

                string selezione = Console.ReadLine();
                switch (selezione)
                {
                    case "1":
                        Console.Clear();
                        rubrica.StampaContatti(rubrica.listaContatti);
                        break;
                    case "2":
                        Console.Clear();
                        rubrica.AggiungiContatto();
                        break;
                    case "3":
                        Console.Clear();
                        rubrica.RicercaContatti();
                        break;
                    case "4":
                        Console.Clear();
                        rubrica.GeneraContattiRandom();
                        break;
                    case "5":
                        Console.Clear();
                        rubrica.EliminaContatto();
                        break;
                    case "6":
                        Console.Clear();
                        rubrica.ModificaContatto();
                        break;
                    case "7":
                        accessoRubrica = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("Arrivederci!");
            Console.ReadKey();
        }
    }
}
