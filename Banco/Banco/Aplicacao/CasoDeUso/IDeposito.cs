using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Aplicacao.CasoDeUso
{
    public interface IDeposito
    {
        Conta Executar(decimal valor, Conta conta);
    }
} 
