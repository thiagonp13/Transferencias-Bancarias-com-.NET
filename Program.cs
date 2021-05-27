using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> Listcontas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                      ListarContas();
                      break;
                      case "2":
                      InserirConta();
                      break;
                      case "3":
                      Transferir();
                      break;
                      case "4":
                      Sacar();
                      break;
                      case "5":
                      Depositar();
                      break;
                      case "C":
                      Console.Clear();                     
                      break;
                      default:
                      throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario= ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            Listcontas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Listcontas[indiceContaOrigem].Tranferir(valorTransferencia, Listcontas[indiceContaDestino]);
            
                
            
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de saque: ");
            double valorSaque = double.Parse(Console.ReadLine());
            Listcontas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta (tipoconta: (Tipoconta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            Listcontas.Add(novaConta);
        }
        private static void ListarContas()
        {
         Console.WriteLine("Listar Contas");

         if (Listcontas.Count == 0)
         {
           Console.WriteLine("Nenhuma conta cadastrada. ");
           return;
         }
         for (int i= 0; i <Listcontas.Count; i++)
         {
             Conta conta = Listcontas[i];
             Console.Write("#{0} - ", i);
             Console.WriteLine(conta);
         }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem Vindo ao DIO Bank!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela ");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
