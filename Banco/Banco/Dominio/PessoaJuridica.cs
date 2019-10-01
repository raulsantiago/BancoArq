using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Dominio
{
    public class PessoaJuridica : Cliente
    {
        public string Cnpj { get; private set; }

        public PessoaJuridica(string nome, string cnpj) : base(nome)
        {   
            this.Cnpj = cnpj;
         }
        public PessoaJuridica() { }

        public override string ToString()
        {
            var texto = "cliente " + this.Nome + " com CNPJ " + this.Cnpj + ";";
            return texto;
        }
    }
}
