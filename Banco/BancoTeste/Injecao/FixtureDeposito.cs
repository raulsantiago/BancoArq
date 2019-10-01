using Autofac;
using Autofac.Core;
using Banco.Aplicacao.CasoDeUso;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoTeste.Injecao
{
    public class FixtureDeposito
    {
        public IContainer Container { get; private set; }

        public FixtureDeposito() 
        {
            // Aqui ele busca a classe concreta exemplo Deposito
            var builder = new ContainerBuilder();
            builder.RegisterType<Deposito>()
                .As<IDeposito>() // a classe IDeposito é a classe Deposito
                .InstancePerDependency();
            Container = builder.Build();
        }
    }
}
