using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjOnTheFly
{
    internal class Passageiro
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public char Situacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaCompra { get; set; }

        public void CadastrarPassageiro(List<Passageiro> listaPassageiro)
        {
            Passageiro passageiro = new Passageiro();

            Console.Write("Insira seu nome completo: ");
            string Nome = Console.ReadLine();
            Console.Write("Insira seu CPF(XXX.XXX.XXX-XX): ");
            string CPF = Console.ReadLine();
            Console.WriteLine("Insira seu sexo:\n01. Feminino(F)\n02. Masculino(M)");
            char Sexo = char.Parse(Console.ReadLine());
            Console.Write("Insira sua data de nascimento (dd/mm/aaaa): ");
            DateTime DataNascimento = DateTime.Parse(Console.ReadLine());
            //Console.Write("Insira sua última compra: ");
            //DateTime UltimaCompra = DateTime.Parse(Console.ReadLine());
            Console.Clear();
        }

        public static void LocalizarPassageiro(List<Passageiro> listaPassageiro, string Cpf)
        {
            Passageiro p = new Passageiro();

            foreach (Passageiro i in listaPassageiro)
            {
                if (i.Cpf == Cpf)
                {
                    foreach (Passageiro pv in listaPassageiro)
                    {
                        p = i;
                        Console.WriteLine("Passageiro localizado!");
                        Console.WriteLine(p);
                    }
                }

            }
        }

        public void EditarPassageiro()
        {
            Passageiro p = new Passageiro();

            Console.Write("Informe o CPF do passageiro para editar: ");
            string Cpf = Console.ReadLine();

            Console.WriteLine("01. Editar nome");
            Console.WriteLine("02. Editar CPF");
            Console.WriteLine("03. Editar sexo");
            Console.WriteLine("04. Editar data de nascimento");
            Console.WriteLine("00. Sair");

            if (Cpf == Cpf)
            {
                Console.WriteLine("CPF encontrado!\nAguarde para a edição!");
                Thread.Sleep(2000);
                Console.Clear();

                int opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Write("Informe um nome novo: ");
                        string Nome = Console.ReadLine();
                        p.Nome = Nome;
                        break;
                    /*case 2:
                        Console.Write("Informe um CPF novo: ");
                        string Cpf = Console.ReadLine();
                        p.Cpf = Cpf;
                        break;*/
                    case 3:
                        Console.Write("Informe o sexo novo: ");
                        char Sexo = char.Parse(Console.ReadLine());
                        p.Sexo = Sexo;
                        break;
                    case 4:
                        Console.Write("Informe um aniversário novo: ");
                        DateTime DataNascimento = DateTime.Parse(Console.ReadLine());
                        p.DataNascimento = DataNascimento;
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Cadastro do passageiro editado com sucesso!");
            }
            else
                Console.WriteLine("CPF não encontrado! Tente novamente.");
        }

        public void ImprimirPassageiro(List<Passageiro> listaPassageiro)
        {
            foreach (Passageiro p in listaPassageiro)
            {

                Console.WriteLine("\n>>>>>>>  PASSAGEIRO <<<<<<");
                Console.WriteLine(p.ToString());
            }

        }

    } 
}
