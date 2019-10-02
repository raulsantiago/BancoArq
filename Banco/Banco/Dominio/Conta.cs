using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Dominio
{
    public class Conta
    {
        public int Agencia { get; private set; }
        public int NumConta { get; private set; }
        public decimal Saldo { get; private set; }
        public EnumTipoConta Tipo { get;  set; }
        public Cliente Dados { get; private set; }
        public List<Extrato> Extratos { get; set; }

        public Conta()
        {
        }

        public Conta(int Agencia, int NumConta, EnumTipoConta Tipo, Cliente Dados)
        {
            this.Agencia = Agencia;
            this.Dados = Dados;
            this.Tipo = Tipo;
            this.Saldo = 0;
            this.NumConta = NumConta;
            Extratos = new List<Extrato>();
        }

        public void SomarSaldo(decimal valor)
        {
            this.Saldo += valor;
        }

        public void DiminuirSaldo(decimal valor)
        {
            this.Saldo -= valor;
        }

        public void AddExtrato(Extrato extrato)
        {
            Extratos.Add(extrato);
        }

        public override string ToString()
        {
            var texto = "agência nº " + this.Agencia + " conta n º " + this.NumConta 
                +" \ntipo " + this.Tipo
                +" \nsaldo " + this.Saldo
                +" \ncliente " + this.Dados.Nome+ ";";
                return texto;
        }

    }
}