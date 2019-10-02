using System;
using System.Collections.Generic;
using System.Text;
using Banco.Aplicacao.CasoDeUso;
using Autofac;
using Mono.CSharp;

namespace Banco.Infraestrutura
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Deposito>().As<IDeposito>();
            builder.RegisterType<Retirada>().As<IRetirada>();
            builder.RegisterType<Transferencia>().As<ITransferencia>();

            return builder.Build();
        }
    }
}
