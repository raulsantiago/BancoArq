using System;
using System.Collections.Generic;
using System.Text;
using Banco.Dominio;


namespace Banco.Aplicacao.CasoDeUso
{
    public class Transferencia : ITransferencia
    {
        public Conta Executar(decimal valor, Conta contaOrigem, Conta contaDestino)
        {            
            contaOrigem.DiminuirSaldo(valor);
            contaDestino.SomarSaldo(valor);
            DateTime data = DateTime.Today;
            contaOrigem.AddExtrato(new Extrato(data, -valor, EnumTransacao.Transferencia));
            contaDestino.AddExtrato(new Extrato(data, valor, EnumTransacao.Transferencia));
            return contaOrigem;
        }

    }
}
