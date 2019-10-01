using System;
using System.Collections.Generic;
using System.Text;
using Banco.Dominio;


namespace Banco.Aplicacao.CasoDeUso
{
    public interface ITransferencia
    {
        Conta Executar(decimal valor, Conta contaOrigem, Conta contaDestino);
    }
}
