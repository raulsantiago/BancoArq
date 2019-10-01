using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Dominio 
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public Cliente(string nome)
        {
            this.Id = new Guid();
            this.Nome = nome;
        }

        public Cliente(){}
    }
}
