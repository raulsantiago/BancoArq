using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Banco.Aplicacao.CasoDeUso
{
    // control . para referenciar 
    public class Deposito : IDeposito
    {
        public Conta Executar(decimal valor, Conta conta)
        {
            conta.SomarSaldo(valor);
            DateTime data = DateTime.Today;
            conta.AddExtrato(new Extrato(data, valor, EnumTransacao.Deposito));
            return conta;
        }
    }
}
