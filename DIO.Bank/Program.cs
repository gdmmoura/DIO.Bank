using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.Write("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("--- Transferência --- ");
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            if (indiceContaOrigem == indiceContaDestino)
            {
                Console.WriteLine();
                Console.WriteLine("As contas de origem e de destino não podem ser as mesmas!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Digite o valor a ser transferido: ");
                double valorTransferencia = double.Parse(Console.ReadLine());

                listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
            }

        }

        private static void Depositar()
        {
            Console.WriteLine("--- Depositar --- ");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine(" --- Sacar --- ");
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("--- Lista de Contas ---");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine(" --- Inserir nova conta --- ");

            Console.WriteLine("Digite 1 para conta física e 2 para jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite valor do crédito: ");
            double valorCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)tipoConta,
                saldo: saldoInicial,
                credito: valorCredito,
                nome: nome);

            listaContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-- DIO.Bank! --");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
