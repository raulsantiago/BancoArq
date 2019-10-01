using Autofac;
using Banco.Aplicacao.CasoDeUso;
using Banco.Dominio;
using System;
using Xunit;

namespace BancoTeste
{
    public class UnitTestDeposito : IClassFixture<Injecao.FixtureDeposito>
    {
        // control . - para injetar depencias em IDeposito
        public readonly IDeposito deposito;


        public Cliente ClienteTeste { get; set; }

        public Conta conta { get; set; }



        // Construtor Para injetar as dependencias.
        public UnitTestDeposito(Injecao.FixtureDeposito fix)
        {
            // morre quando não mais utilizado
            this.deposito = fix.Container.Resolve<IDeposito>();
            this.ClienteTeste = new PessoaFisica("Raul Santiago", "530.280.270-87");// mocar mok 
            this.conta = new Conta(0838, 12345678, this.ClienteTeste);// mocar mok 

        }
        [Fact]
        public void Test1()
        {
            //new Conta = new Conta;
            var retorno = deposito.Executar(10.5m, this.conta);
            // fluente validation pe melhor para verificar o teste
            Assert.True(retorno.Saldo == 10.5m);

        }
    }
}