using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Aplicacao.CasoDeUso
{
    // control . para referenciar 
    public class Deposito : IDeposito
    {
        public Conta Executar(decimal valor, Conta conta)
        {
            conta.SomarSaldo(valor);
            return conta;
        }
    }
}
