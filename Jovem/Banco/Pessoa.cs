using System;

namespace Jovem.Banco
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
