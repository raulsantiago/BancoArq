using Autofac;
using Autofac.Core;
using Banco.Aplicacao.CasoDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoTeste.Injecao
{
    public class FixtureRetirada
    {
        public IContainer Container { get; private set; }

        public FixtureRetirada()
        {
            // Aqui ele busca a classe concreta exemplo Retirada
            var builder = new ContainerBuilder();
            builder.RegisterType<Retirada>()
              .As<IRetirada>() // a classe IDeposito é a classe Retirada
              .InstancePerDependency();
             Container = builder.Build();
        }
    }
}
