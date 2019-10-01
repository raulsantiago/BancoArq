using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Dominio
{
    public class PessoaFisica : Cliente
    {
        public string Cpf { get; private set; }
        
        public PessoaFisica(string nome, string cpf) : base(nome)
        {            
            this.Cpf = cpf;
        }
        public PessoaFisica() { }

        public override string ToString()
        {
            var texto = "cliente " + this.Nome + " com CPF " + this.Cpf+";";
            return texto; 
        }

}
}
