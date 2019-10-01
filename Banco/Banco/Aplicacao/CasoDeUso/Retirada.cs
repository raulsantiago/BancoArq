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
            return conta;
        }
    }
}


