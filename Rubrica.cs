using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica___Console
{
    public class Rubrica
    {
        public List<Contatto> listaContatti { get; set; } = new List<Contatto>();

        public void IntroRubrica()
        {
            Console.WriteLine("Benvenuto nella tua rubrica!");
        }

        private void Continuare()
        {
            Console.WriteLine("Premi un tasto qualsiasi per continuare...");
            Console.ReadKey();
        }

        // aggiunge un contatto definito dall'utente
        public void AggiungiContatto()
        {
            Console.WriteLine("Digita il nome:");
            string nome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Digita il cognome:");
            string cognome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Digita il telefono:");
            string telefono = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Digita l'email:");
            string email = Console.ReadLine();
            Console.Clear();

            Contatto nuovoContatto = new Contatto(nome, cognome, telefono, email, 0);
            this.listaContatti.Add(nuovoContatto);
            this.AggiornaRubrica();

            Console.WriteLine("Contatto aggiunto!");
            Console.WriteLine();

            this.Continuare();
        }

        // grazie alla classe RandomNameGenerator trovata su internet, genera un numero definito dall'utente di contatti casuali e li aggiunge alla lista contatti
        public void GeneraContattiRandom()
        {
            Console.WriteLine("Quanti contatti vuoi generare?");
            string inputUtente = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(inputUtente, out int input))
            {
                Random randomPhoneNumber = new Random();
                RandomNameGenerator randomNameGenerator = new RandomNameGenerator();
                for (int i = 0; i < input; i++)
                {
                    string[] nomeGenerato = randomNameGenerator.GenerateName();
                    Contatto contattoGenerato = new Contatto(nomeGenerato[0], nomeGenerato[1], randomPhoneNumber.Next(111111111, 999999999).ToString(), $"{nomeGenerato[0].ToLowerInvariant()}.{nomeGenerato[1].ToLowerInvariant()}@email.com", i + 1);
                    this.listaContatti.Add(contattoGenerato);
                    this.AggiornaRubrica();

                }
                Console.WriteLine("Generati " + input + " contatti casuali!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Input non valido. Devi inserire un numero.");
                Console.WriteLine();
            }
            this.Continuare();
        }

        // stampa la lista contatti che gli viene passata come parametro
        public void StampaContatti(List<Contatto> listaContatti)
        {
            if (this.listaContatti.Count > 0)
            {
                Console.Clear();
                for (int i = 0; i < listaContatti.Count; i++)
                {
                    Console.WriteLine($"ID contatto: " + listaContatti[i].Id);
                    Console.WriteLine($"Nome: " + listaContatti[i].Nome);
                    Console.WriteLine($"Cognome: " + listaContatti[i].Cognome);
                    Console.WriteLine($"Telefono: " + listaContatti[i].Telefono);
                    Console.WriteLine($"Email: " + listaContatti[i].Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nessun contatto presente in rubrica!");
                Console.WriteLine();
            }
            this.Continuare();
        }

        // ricerca contatti nella lista contatti di questa rubrica
        public void RicercaContatti()
        {
            Console.WriteLine("Digita la parola da cercare:");
            string ricerca = Console.ReadLine().ToLowerInvariant();
            Console.WriteLine();
            List<Contatto> contattiTrovati = this.listaContatti.Where(contatto =>
                contatto.Nome.Contains(ricerca) ||
                contatto.Cognome.Contains(ricerca) ||
                contatto.Telefono.Contains(ricerca) ||
                contatto.Email.Contains(ricerca)).ToList();
            if (contattiTrovati.Count > 0)
            {
                this.StampaContatti(contattiTrovati);
            }
            else
            {
                Console.WriteLine("Nessun contatto trovato!");
                Console.WriteLine();
            }
            this.Continuare();
        }

        public void EliminaContatto()
        {
            this.StampaContatti(listaContatti);
            Console.WriteLine("Inserisci l'ID del contatto che vuoi eliminare:");
            string id = Console.ReadLine();
            Console.WriteLine();
            int inputId = 0;
            if (int.TryParse(id, out inputId))
            {
                if (inputId > 0 && inputId <= listaContatti.Count)
                {
                    this.listaContatti.RemoveAt(inputId - 1);
                    this.AggiornaRubrica();
                    Console.WriteLine("Contatto eliminato!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Input non valido.");
                Console.WriteLine();
            }
            this.Continuare();
        }

        public void ModificaContatto()
        {
            this.StampaContatti(listaContatti);
            Console.WriteLine("Inserisci l'ID del contatto che vuoi modificare:");
            string id = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            int inputId = 0;
            if (int.TryParse(id, out inputId))
            {
                if (inputId > 0 && inputId <= listaContatti.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Digita il nome:");
                    string nome = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Digita il cognome:");
                    string cognome = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Digita il telefono:");
                    string telefono = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Digita l'email:");
                    string email = Console.ReadLine();
                    Console.Clear();
                    Contatto contattoModificato = new Contatto(nome, cognome, telefono, email, inputId);
                    this.listaContatti.RemoveAt(inputId - 1);
                    this.listaContatti.Insert(inputId - 1, contattoModificato);
                    Console.WriteLine("Contatto modificato!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Input non valido.");
                Console.WriteLine();
            }
            this.Continuare();
        }

        // assegna gli id corretti ai contatti
        public void AggiornaRubrica()
        {
            this.Ordina();
            for (int i = 0; i < this.listaContatti.Count; i++)
            {
                this.listaContatti[i].Id = i + 1;
            }
        }

        // metti in ordine alfabetico la lista
        public void Ordina()
        {
            this.listaContatti = listaContatti.OrderBy(x => x.Cognome).ToList();
        }
    }
}
