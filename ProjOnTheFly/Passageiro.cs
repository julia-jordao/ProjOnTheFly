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

        public Passageiro()
        {

        }

        public Passageiro(string Cpf, string Nome, DateTime DataNascimento, char Sexo, DateTime UltimaCompra, DateTime DataCadastro, char Situacao)
        {
            this.Cpf = Cpf;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Sexo = Sexo;
            this.UltimaCompra = DateTime.Now;
            this.DataCadastro = DateTime.Now;
            this.Situacao = 'A';
        }

        public static string ReadCPF(string text)
        {
            string cpfString;
            long cpfLong;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];
            bool digitosIguais = false;

            do
            {
                Console.Write(text);
                cpfString = Console.ReadLine();
                while (!long.TryParse(cpfString, out cpfLong))
                {
                    Console.Write("Digite um CPF valido!\n{0}", text);
                    cpfString = Console.ReadLine();
                }
                digVerificador = (int)(cpfLong % 100);
                cpfLong /= 100;
                for (int i = 0; i < 9; i++)
                {
                    aux = (int)cpfLong % 10;
                    digitosCPF[i] = aux;
                    cpfLong /= 10;
                }
                digitosIguais = false;
                for (int i = 0; i < digitosCPF.Length; i++)
                {
                    if (i == digitosCPF.Length - 1)
                    {
                        Console.WriteLine("O CPF nao segue as regras de validacao da Receita Federal!");
                        digitosIguais = true;
                        break;
                    }
                    if (digitosCPF[i] != digitosCPF[i + 1]) break;
                }
                if (digitosIguais) continue;
                v1 = v2 = 0;
                for (int i = 0; i < 9; i++)
                {
                    v1 += digitosCPF[i] * (9 - i);
                    v2 += digitosCPF[i] * (8 - i);
                }
                v1 = (v1 % 11) % 10;
                v2 += v1 * 9;
                v2 = (v2 % 11) % 10;
                if (v1 * 10 + v2 == digVerificador) return cpfString;
                else Console.WriteLine("O CPF nao segue as regras de validacao da Receita Federal!");
            } while (true);
        }

        public Passageiro CadastrarPassageiro(List<Passageiro> listaPassageiro)
        {
            Passageiro passageiro = new Passageiro();

            Console.Clear();
            Console.WriteLine("Formulário de cadastro:\n");
            do
            {
                Console.Write("Insira seu nome completo:  ");
                passageiro.Nome = Console.ReadLine();
                if (passageiro.Nome.Length > 50)
                {
                    Console.WriteLine("\nQuantidade de caracteres ultrapassou o limite!\nDigite novamente!");
                }
            } while (passageiro.Nome.Length > 50);

            string Cpf = ReadCPF("Insira seu CPF: ");

            Console.WriteLine("Insira seu sexo:\n01. Feminino(F)\n02. Masculino(M)\n03. Prefiro não dizer(N)");
            char Sexo = char.Parse(Console.ReadLine());
            passageiro.Sexo = Sexo;


            Console.Write("Insira sua data de nascimento (dd/mm/aaaa): ");
            DateTime DataNascimento = DateTime.Parse(Console.ReadLine());
            passageiro.DataNascimento = DataNascimento;

            Console.WriteLine("Insira sua situaçõa de cadastro:\n01. Ativo (A)\n02. Inativo (I)");
            char Situacao = char.Parse(Console.ReadLine());
            passageiro.Situacao = Situacao;

            Console.Write("Ultima Compra: ");
            UltimaCompra = DateTime.Now;
            Console.WriteLine(UltimaCompra);

            Console.Write("Data cadastro: ");
            DataCadastro = DateTime.Now;
            Console.WriteLine(DataCadastro);

            Console.WriteLine("\nCadastro realizado com sucesso!\nVoltando ao menu principal!\nPor favor aguarde.");
            Thread.Sleep(2000);
            listaPassageiro.Add(passageiro);
            return passageiro;

        }

        public void LocalizarPassageiro(List<Passageiro> listaPassageiro)
        {
            string op = "-1";
            string msg = "";
            string inputCpf;
            string[] options = new string[] { "1", "0" };
            bool b;

            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("Localização de passageiro: ");
                Console.WriteLine("\nInforme a operação desejada: ");
                Console.WriteLine("01. Localizar");
                Console.WriteLine("00. Voltar");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Program.ReadString("Opcao: ");
                if (!Program.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente.";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        b = false;
                        inputCpf = Program.ReadStringCpf("Digite o CPF do passageiro: ");

                        foreach (Passageiro passageiro in listaPassageiro)
                        {
                            if (passageiro.Cpf == inputCpf)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(passageiro);
                                Program.ReadString("\nVoltando ao menu principal!\nPor favor aguarde.");
                                b = true;
                                Thread.Sleep(2000);
                                Console.Clear();
                            };
                        }
                        if (!b)
                        {
                            Program.ReadString("Passageiro não encontrado!\nPor favor aguarde.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                    case "0":
                        return;
                }
            }
        }

        public void EditarPassageiro(List<Passageiro> listaPassageiro)
        {
            Passageiro passageiro = new Passageiro();

            Console.Clear();
            Console.WriteLine("Escolha a opção que deseja editar!");
            Console.WriteLine("01. Editar nome");
            Console.WriteLine("02. Editar CPF");
            Console.WriteLine("03. Editar sexo");
            Console.WriteLine("04. Editar data de nascimento");
            Console.WriteLine("00. Sair");

            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.Write("Informe um nome novo: ");
                    string Nome = Console.ReadLine();
                    passageiro.Nome = Nome;
                    break;
                case 2:
                    Console.Write("Informe um CPF novo: ");
                    string CPF = Console.ReadLine();
                    passageiro.Cpf = Cpf;
                    break;
                case 3:
                    Console.Write("Informe o sexo novo: ");
                    char Sexo = char.Parse(Console.ReadLine());
                    passageiro.Sexo = Sexo;
                    break;
                case 4:
                    Console.Write("Informe um aniversário novo: ");
                    DateTime DataNascimento = DateTime.Parse(Console.ReadLine());
                    passageiro.DataNascimento = DataNascimento;
                    break;

                default:
                    break;
            }
            Console.WriteLine("Cadastro do passageiro editado com sucesso!");
            Console.Clear();
        }

        public void ImprimirPassageiro(List<Passageiro> listaPassageiro)
        {
            foreach (Passageiro passageiro in listaPassageiro)
            {
                if (Situacao == 1)
                {
                    Console.Clear();
                    Console.WriteLine(passageiro.ToString());
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                    Console.WriteLine("Cadastro do passageiro inativo!");

            }
        }

        public override string ToString()
        {
            return ($"Nome: {this.Nome}\nCPF: {this.Cpf}\nSexo: {this.Sexo}\nDada de nascimento: {this.DataNascimento}\nÚltima compra: {this.UltimaCompra}\nData do cadastro: {this.DataCadastro}\nSituação de cadastro: {this.Situacao}");
        }

    }
}