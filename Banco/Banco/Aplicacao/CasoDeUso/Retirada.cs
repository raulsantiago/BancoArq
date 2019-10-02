using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Aplicacao.CasoDeUso
{
    public class Retirada : IRetirada
    {
        public Conta Executar(decimal valor, Conta conta)
        {
            conta.DiminuirSaldo(valor);
            DateTime data = DateTime.Today;
            conta.AddExtrato(new Extrato(data, -valor, EnumTransacao.Saque));
            return conta;
        }
    }
}


