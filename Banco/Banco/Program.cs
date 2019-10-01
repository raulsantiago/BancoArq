using Autofac;
using Banco.Aplicacao.CasoDeUso;
using Banco.Dominio;
using System;

namespace Banco
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Aqui ele busca a classe concreta exemplo Deposito
            var builder = new ContainerBuilder();            
            builder.RegisterType<Deposito>()
                .As<IDeposito>() // a classe IDeposito é a classe Deposito
                .InstancePerDependency();
            IContainer container = builder.Build();

            // Aqui roda o teste de Deposito em produção
            Cliente x;
            Conta y;            
            x = new PessoaFisica("Raul Santiago", "530.280.270-87");
            y = new Conta(0838, 12345678, EnumTipoConta.Poupanca, x);            
            IDeposito dr = new Deposito();
            var d = dr.Executar(10.5m, y);
            Console.WriteLine("++++++++DEPOSITO+++++++++");
            Console.WriteLine("Saldo atual após depósito: R$ "+d.Saldo.ToString("F2")+" do "+x.ToString());

            // Aqui ele busca a classe concreta exemplo Deposito
            var builder2 = new ContainerBuilder();            
            builder2.RegisterType<Retirada>()
                .As<IRetirada>() // a classe IRetirada é a classe Retirada
                .InstancePerDependency();
            IContainer container2 = builder2.Build();

            // Aqui roda o teste de Retirada em produção
            Cliente a;
            Conta b;
            a = new PessoaJuridica("Empresa Raul", "14.234.432/0001-80");
            b = new Conta(0838, 12345678, EnumTipoConta.Corrente, a);
            IRetirada dr2 = new Retirada();
            var c = dr2.Executar(1.95m, b);
            Console.WriteLine("++++++++RETIRADA/SAQUE+++++++++");
            Console.WriteLine("Saldo atual após retirada: R$ " + c.Saldo.ToString("F2")+" do "+a.ToString());

            Console.WriteLine("++++++++TRANSFERENCIA+++++++++");
            Console.WriteLine("Saldo R$"+d.Saldo.ToString("F2")+" ANTES da tranferencia do "+x.ToString());
            var builder3 = new ContainerBuilder();
            builder3.RegisterType<Transferencia>()
                .As<ITransferencia>() // a classe IRetirada é a classe Retirada
                .InstancePerDependency();
            IContainer container3 = builder3.Build();
           
            ITransferencia tr = new Transferencia();
            var tra = tr.Executar(5.0m, y, b);
            Console.WriteLine("++++++++TRANSFERENCIA REALIZADA+++++++++");
            Console.WriteLine("Saldo R$" + d.Saldo.ToString("F2") + " DEPOIS da tranferencia do " + x.ToString());







        }
    }
}