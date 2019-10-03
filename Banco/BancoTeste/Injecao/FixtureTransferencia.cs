using Autofac;
using Autofac.Core;
using Banco.Aplicacao.CasoDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoTeste.Injecao
{
    public class FixtureTransferencia
    {
        public IContainer Container { get; private set; }

        public FixtureTransferencia()
        {
            // Aqui ele busca a classe concreta exemplo Retirada
            var builder = new ContainerBuilder();
            builder.RegisterType<Transferencia>()
              .As<ITransferencia>() // a classe IDeposito é a classe Retirada
              .InstancePerDependency();
            Container = builder.Build();
        }

    }
}
