using System;
using System.Collections.Generic;

namespace DioBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = menuUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        //Transferir();
                        break;
                    case "4":
                        //Sacar();
                        break;
                    case "5":
                        //Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = menuUsuario();   
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadKey();
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Saque(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Saque(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTranfer = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTranfer, listContas[indiceContaDestino]);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista contas ");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi encontrada ");
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} ", i);
                Console.WriteLine(conta);
            }
        }


        private static void inserirConta()
        {
            Console.WriteLine("Inserir uma conta");
            Console.WriteLine("Digite 1 para Pessoa Física ou digite 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Infome o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Infome o crédito desejado: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Console.WriteLine("Infome o saldo da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());


            Conta novaConta = new Conta(tipoConta: (TipoConta) entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string menuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a Dio Bank ");
            Console.WriteLine();
            Console.WriteLine("Infome a opção desejada");
            Console.WriteLine("1 - Listar contas ");
            Console.WriteLine("2 - Iserir nova conta ");
            Console.WriteLine("1 - Transferir ");
            Console.WriteLine("4 -  Sacar ");
            Console.WriteLine("5 - Depositar ");
            Console.WriteLine("6 - Limpar Tela ");
            Console.WriteLine("X - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
