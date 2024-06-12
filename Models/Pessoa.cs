using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Models
{
    public class Pessoa
    {
        public Pessoa()
        {

        }
        public Pessoa(string id, string nome, string senha)
        {
            ID = id;
            Nome = nome;
            Senha = senha;
        }

        public string ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Enderesso { get; set; }
        public string Classe { get; set; }
        public int Celular { get; set; }
        public int Idade { get; set; }

        public virtual void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade}. Sou professor e meu salario é: " );
        }
    }
}