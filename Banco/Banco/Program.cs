using Autofac;
using Banco.Aplicacao.CasoDeUso;
using Banco.Dominio;
using Banco.Infraestrutura;
using System;

namespace Banco
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Aqui ele busca a classe concreta exemplo Deposito
            // Aqui roda o teste de Deposito em produção
            IContainer container = ContainerConfig.Configure();
            Cliente Primeiro;
            Conta PrimeiraConta;
            Primeiro = new PessoaFisica("Raul Santiago", "530.280.270-87");
            PrimeiraConta = new Conta(0838, 12345678, EnumTipoConta.Poupanca, Primeiro);
            container.Resolve<IDeposito>().Executar(10.5m, PrimeiraConta);
            Console.WriteLine("++++++++DEPOSITO+++++++++");
            Console.WriteLine("Saldo atual após depósito: R$ " + PrimeiraConta.Saldo.ToString("F2") + " do " + Primeiro.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: "+ PrimeiraConta.Agencia+" Nº Conta: "+ PrimeiraConta.NumConta);
            foreach (Extrato extrato in PrimeiraConta.Extratos)
            {   
                Console.WriteLine(extrato);
            }

            // Aqui ele busca a classe concreta exemplo Deposito e roda o teste de Retirada em produção
            Cliente Segundo;
            Conta SegundaConta;
            Segundo = new PessoaJuridica("Empresa Luar", "14.234.432/0001-80");
            SegundaConta = new Conta(0026, 0406363, EnumTipoConta.Corrente, Segundo);
            container.Resolve<IRetirada>().Executar(1.95m, SegundaConta);
            Console.WriteLine();
            Console.WriteLine("++++++++RETIRADA/SAQUE+++++++++");
            Console.WriteLine("Saldo atual após retirada: R$ " + SegundaConta.Saldo.ToString("F2")+" do "+ Segundo.ToString());            
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + SegundaConta.Agencia + " Nº Conta: " + SegundaConta.NumConta);
            foreach (Extrato extrato in SegundaConta.Extratos)
            {
                Console.WriteLine(extrato);
            }
            
            container.Resolve<IRetirada>().Executar(2.00m, PrimeiraConta);
            Console.WriteLine();
            Console.WriteLine("++++++++RETIRADA+++++++++");
            Console.WriteLine("Saldo atual após retirada: R$ " + PrimeiraConta.Saldo.ToString("F2") + " do " + Primeiro.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + PrimeiraConta.Agencia + " Nº Conta: " + PrimeiraConta.NumConta);
            foreach (Extrato extrato in PrimeiraConta.Extratos)
            {
                Console.WriteLine(extrato);
            }

            container.Resolve<ITransferencia>().Executar(5.0m, PrimeiraConta, SegundaConta);
            Console.WriteLine();
            Console.WriteLine("++++++++TRANSFERENCIA+++++++++");
            Console.WriteLine("Saldo R$" + PrimeiraConta.Saldo.ToString("F2") + " DEPOIS da tranferencia do " + Primeiro.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + PrimeiraConta.Agencia + " Nº Conta: " + PrimeiraConta.NumConta);
            foreach (Extrato extrato in PrimeiraConta.Extratos)
            {
                Console.WriteLine(extrato);
            }

            Console.WriteLine();
            Console.WriteLine("++++++++SALDO+++++++++");
            Console.WriteLine("Saldo atual após transferência: R$ " + SegundaConta.Saldo.ToString("F2") + " do " + Segundo.ToString());
            Console.WriteLine("++++EXTRATO++++");
            Console.WriteLine("Nº Agência: " + SegundaConta.Agencia + " Nº Conta: " + SegundaConta.NumConta);
            foreach (Extrato extrato in SegundaConta.Extratos)
            {
                Console.WriteLine(extrato);
            }



        }
    }
}