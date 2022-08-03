using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica___Console
{
    public class Contatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contatto(string nome, string cognome, string telefono, string email, int id)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cognome = cognome;
            this.Telefono = telefono;
            this.Email = email;
        }
    }
}
