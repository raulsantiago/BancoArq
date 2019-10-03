using Autofac;
using Banco.Aplicacao.CasoDeUso;
using Banco.Dominio;
using System;
using Xunit;

namespace BancoTeste
{
    public class UnitTestTransferencia : IClassFixture<Injecao.FixtureTransferencia>
    {
        // control - para injetar depencias em IRetirada
        public readonly ITransferencia transferencia;

        public Cliente ClientePrimeiro { get; set; }

        public Cliente ClienteSegundo { get; set; }

        public Conta ContaPrimeiro { get; set; }

        public Conta ContaSegundo { get; set; }

        // Construtor Para injetar as dependencias Deposito.
        public UnitTestTransferencia(Injecao.FixtureTransferencia fix)
        {
            // morre quando não mais utilizado
            this.transferencia = fix.Container.Resolve<ITransferencia>();
            this.ClientePrimeiro = new PessoaFisica("Raul Santiago", "222.333.333.-90");// mocar mok 
            this.ClienteSegundo = new PessoaJuridica("Empresa Ago", "15.432.444/0009-90");// mocar mok 
            this.ContaPrimeiro = new Conta(0838, 12345678, EnumTipoConta.Corrente, this.ClientePrimeiro);// mocar mok 
            this.ContaSegundo = new Conta(9999, 09876544, EnumTipoConta.Poupanca, this.ClienteSegundo);// mocar mok 
            DateTime data = DateTime.Today;
            ContaPrimeiro.AddExtrato(new Extrato(data, -5.0m, EnumTransacao.Transferencia));
            ContaSegundo.AddExtrato(new Extrato(data, 5.0m, EnumTransacao.Transferencia));
            
        }
        [Fact]
        public void TestTransferencia()
        {
            var retorno = transferencia.Executar(5.0m, ContaPrimeiro, ContaSegundo);
            Assert.True(retorno.Saldo == -5.00m);
        }

        
    }
}
