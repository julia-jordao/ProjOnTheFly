using System;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ProjOnTheFly
{
    internal class Program
    {
        internal static bool BuscarNoArray(string op, string[] options)
        {
            for (int i = 0; i < options.Length; i++)
                if (options[i] == op) return true;
            return false;
        }

        internal static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        internal static string ReadStringCpf(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int escolha = 0;

            List<Passageiro> listaPassageiro = new List<Passageiro>();
            Passageiro passageiro = new Passageiro();

            Console.WriteLine("Bem-vindo(a)!");
            do
            {
                Console.WriteLine("\nMENU DE OPÇÕES:\n01. Cadastrar\n02. Localizar\n03. Editar\n04. Ver Cadastro\n00. Sair");
                escolha = int.Parse(Console.ReadLine());
                //MENU PRINCIPAL
                //CADASTRAR
                if (escolha == 1)
                {
                    passageiro.CadastrarPassageiro(listaPassageiro);
                }
                //LOCALIZAR
                else if (escolha == 2)
                {
                    passageiro.LocalizarPassageiro(listaPassageiro);
                }
                //EDITAR
                else if (escolha == 3)
                {
                    passageiro.EditarPassageiro(listaPassageiro);
                }
                //IMPRIMIR
                else if (escolha == 4)
                {
                    passageiro.ImprimirPassageiro(listaPassageiro);
                }
                //SAIR
                else if (escolha == 0)
                {
                    Console.WriteLine("Agradecemos a preferência, volte sempre!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Opção inexistente!");
                    Console.Clear();
                }
            } while (true);
            Console.Clear();
        }
    }
}