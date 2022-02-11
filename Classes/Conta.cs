using System;
namespace DioBank
{
    public class Conta
    {
        private TipoConta TipoConta {get ; set ;}
        private double Saldo {get ; set ;}
        private double Credito  {get ; set ;}
        private string Nome {get ; set ;}
        
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Saque(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * (-1)) )
            {
                Console.WriteLine("Saldo indisponivel. ");
                return false;
            }else
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é de R${1},00. ",this.Nome, this.Saldo);
            }
            return true;
        }

        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é de R${1},00. ",this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {   
            if(this.Saque(valorTransferencia));
            {
                contaDestino.Deposito(valorTransferencia);
            }
            
        }
        
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + ",00 | ";
            retorno += "Crédito: R$ " + this.Credito + ",00.";
            return retorno;

        }
    }
}