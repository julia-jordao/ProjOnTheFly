using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjOnTheFly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;

            List<Passageiro> listaPassageiro = new List<Passageiro>();
            Passageiro passageiro = new Passageiro();

            passageiro.CadastrarPassageiro(listaPassageiro);
            //passageiro.ImprimirPassageiro(List<Passageiro> listaPassageiro);
            //passageiro.LocalizarPassageiro(List<Passageiro> listaPassageiro);
            //passageiro.EditarPassageiro(List<Passageiro> listaPassageiro);

            //MENU PRINCIPAL
            while(escolha != 0 && escolha != 1 && escolha != 2 && escolha != 3 && escolha != 4)
            {
                Console.WriteLine("MENU DE OPÇÕES:\n01. Cadastrar\n02. Localizar\n03. Editar\n04. Ver Cadastro\n00. Sair");
                escolha = int.Parse(Console.ReadLine());
                Console.Clear();
                if(escolha == 1)//CADASTRO
                {
                    Console.WriteLine("Formulário de cadastro:");
                    //passageiro = passageiro.CadastrarPassageiro(List<Passageiro> listaPassageiro);
                    Console.WriteLine("Voltando ao menu principal!\nPor favor aguarde.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if(escolha == 2)//LOCALIZAR
                {
                    Console.Clear();
                    Console.WriteLine("Insira ");
                    string validacaoCPF = Console.ReadLine();
                    Passageiro searchPassageiro = null;
                }
                else if (escolha == 3)//EDITAR
                {
                    Console.Clear();
                    //passageiro = passageiro.EditarPassageiro(List<Passageiro> listaPassageiro);
                    Console.WriteLine("Voltando ao menu principal!\nPor favor aguarde.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (escolha == 4)//IMPRIMIR
                {
                }
                else if(escolha == 0)//SAIR
                {
                    Console.WriteLine("Agradecemos a preferência, volte sempre!");
                }
                else
                    Console.WriteLine("Opção inexistente!");
            }
        }
    }
}
