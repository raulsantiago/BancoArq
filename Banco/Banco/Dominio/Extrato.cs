using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Banco.Dominio
{
    public class Extrato
    {
        public DateTime dataTransacao { get; set; }
        public decimal valorTransacao { get; set; }
        public EnumTransacao TipoTransacao { get; set; }

        public Extrato(DateTime dataTransacao, decimal valorTransacao, EnumTransacao tipoTransacao)
        {
            this.dataTransacao = dataTransacao;
            this.valorTransacao = valorTransacao;
            TipoTransacao = tipoTransacao;
        }

        Conta cont = new Conta();

        public override string ToString()
        {
            return this.dataTransacao.ToString("dd/MM/yyyy")
                + " | "
                + TipoTransacao.ToString()
                + " | R$ "
                + this.valorTransacao.ToString("F2", CultureInfo.InvariantCulture);
        }


    }
}
