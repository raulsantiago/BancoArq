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
            dr.Executar(10.5m, y);
            Console.WriteLine("++++++++DEPOSITO+++++++++");
            Console.WriteLine("Saldo atual após depósito: R$ " + y.Saldo.ToString("F2") + " do " + x.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: "+y.Agencia+" Nº Conta: "+y.NumConta);
            foreach (Extrato extrato in y.Extratos)
            {   
                Console.WriteLine(extrato);
            }

            // Aqui ele busca a classe concreta exemplo Deposito
            var builder2 = new ContainerBuilder();            
            builder2.RegisterType<Retirada>()
                .As<IRetirada>() // a classe IRetirada é a classe Retirada
                .InstancePerDependency();
            IContainer container2 = builder2.Build();
            // Aqui roda o teste de Retirada em produção
            Cliente a;
            Conta b;
            a = new PessoaJuridica("Empresa Luar", "14.234.432/0001-80");
            b = new Conta(0026, 0406363, EnumTipoConta.Corrente, a);
            IRetirada dr2 = new Retirada();
            var c = dr2.Executar(1.95m, b);
            Console.WriteLine();
            Console.WriteLine("++++++++RETIRADA/SAQUE+++++++++");
            Console.WriteLine("Saldo atual após retirada: R$ " + c.Saldo.ToString("F2")+" do "+a.ToString());            
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + b.Agencia + " Nº Conta: " + b.NumConta);
            foreach (Extrato extrato in b.Extratos)
            {
                Console.WriteLine(extrato);
            }
            
            var builder4 = new ContainerBuilder();
            builder4.RegisterType<Retirada>()
                .As<IRetirada>() 
                .InstancePerDependency();
            IContainer container4 = builder4.Build();           
            IRetirada dr4 = new Retirada();
            dr4.Executar(2.00m, y);
            Console.WriteLine();
            Console.WriteLine("++++++++RETIRADA+++++++++");
            Console.WriteLine("Saldo atual após retirada: R$ " + y.Saldo.ToString("F2") + " do " + x.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + y.Agencia + " Nº Conta: " + y.NumConta);
            foreach (Extrato extrato in y.Extratos)
            {
                Console.WriteLine(extrato);
            }

            var builder3 = new ContainerBuilder();
            builder3.RegisterType<Transferencia>()
                .As<ITransferencia>() // a classe IRetirada é a classe Retirada
                .InstancePerDependency();
            IContainer container3 = builder3.Build();            
            ITransferencia tr = new Transferencia();
            tr.Executar(5.0m, y, b);
            Console.WriteLine();
            Console.WriteLine("++++++++TRANSFERENCIA+++++++++");
            Console.WriteLine("Saldo R$" + y.Saldo.ToString("F2") + " DEPOIS da tranferencia do " + x.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + y.Agencia + " Nº Conta: " + y.NumConta);
            foreach (Extrato extrato in y.Extratos)
            {
                Console.WriteLine(extrato);
            }

            Console.WriteLine();
            Console.WriteLine("++++++++SALDO+++++++++");
            Console.WriteLine("Saldo atual após transferência: R$ " + c.Saldo.ToString("F2") + " do " + a.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + b.Agencia + " Nº Conta: " + b.NumConta);
            foreach (Extrato extrato in b.Extratos)
            {
                Console.WriteLine(extrato);
            }



        }
    }
}