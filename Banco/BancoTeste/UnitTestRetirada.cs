using Autofac;
using Banco.Aplicacao.CasoDeUso;
using Banco.Dominio;
using System;
using Xunit;

namespace BancoTeste
{
    public class UnitTestRetirada : IClassFixture<Injecao.FixtureRetirada>
    {
        // control - para injetar depencias em IRetirada
        public readonly IRetirada retirada;

        public Cliente ClienteTeste { get; set; }

        public Conta conta { get; set; }

        // Construtor Para injetar as dependencias Deposito.
        public UnitTestRetirada(Injecao.FixtureRetirada fix)
        {
            // morre quando não mais utilizado
            this.retirada = fix.Container.Resolve<IRetirada>();
            this.ClienteTeste = new PessoaJuridica("Empresa Ago", "15.432.444/0009-90");// mocar mok 
            this.conta = new Conta(0838, 12345678, EnumTipoConta.Poupanca, this.ClienteTeste);// mocar mok 
        }
        [Fact]
        public void Test2()
        {
            var retorno = retirada.Executar(1.95m, this.conta);
            // fluente validation pe melhor para verificar o teste
            Assert.True(retorno.Saldo == -1.95m);
        }
    }
}
