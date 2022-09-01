using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Lembrete // Objeto que irá receber as informações digitadas pelo usuário
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public int ID { get; set; }
    }
    internal class Program
    {
        enum Menu { Criar = 1, Deletar, Exibir, Sair }

        public static List<Lembrete> Eventos = new List<Lembrete>();
        static void Main(string[] args)
        {
            bool saiu = false;

            while (!saiu) // Estrutura para manter o loop de exibição do menu
            {
                Console.WriteLine("");
                Console.WriteLine("Criador de lembretes");
                Console.WriteLine("Selecione o número da opção desejada");
                Console.WriteLine("Criar Lembrete = 1\nDeletar Lembrete = 2\nExibir Lembretes = 3\nSair = 4");
                Console.WriteLine("");
                Console.Write("Opção: ");

                Menu OP = (Menu)int.Parse(Console.ReadLine());

                try
                {
                    switch (OP)
                    {
                        case Menu.Criar:
                            Cria();
                            break;

                        case Menu.Deletar:
                            Deleta();
                            break;

                        case Menu.Exibir:
                            Exiba();
                            break;

                        case Menu.Sair:
                            saiu = true;
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            Console.WriteLine("");
                            break;



                    }

                }
                catch (Exception ex) // Informar erro ao usuário caso a data seja inválida
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ERRO: {ex.Message}");
                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("");

                }

                // Funções para cada opção do MENU

                static void Cria()
                {
                    Console.WriteLine("");
                    Console.WriteLine("Criar Lembrete");
                    Console.WriteLine("Digite o nome do lembrete: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("Digite a data do lembrete no formato (dd/mm/aaaa)");
                    string data = Console.ReadLine();
                    if (DateTime.Parse(data) < DateTime.Today)
                    {
                        throw new Exception("Data inválida");

                    }
                    Eventos.Add(new Lembrete { Nome = nome, Data = DateTime.Parse(data), ID = (Eventos.Count() + 1) });
                    Console.WriteLine("");
                    Console.WriteLine("Lembrete Adicionado");
                    Console.WriteLine("Nome = " + nome);
                    Console.WriteLine("Data = " + data);
                    Console.WriteLine("");

                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }

                static void Exiba()
                {
                    if (Eventos.Count < 1)
                    {
                        Console.WriteLine("Não há lembretes para exibir");
                    }
                    else
                    {
                        Console.WriteLine("LISTA DE LEMBRETES: ");
                        foreach (var item in Eventos.OrderByDescending(x => x.Data))
                        {
                            Console.WriteLine("");

                            Console.WriteLine($"Lembrete: {item.Nome} - Data: {item.Data.ToShortDateString()} - ID: {item.ID}");
                            Console.WriteLine("============================================================");
                        }
                    }

                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadLine();



                }

                static void Deleta()
                {
                    Console.WriteLine("Deletar lembrete");
                    Exiba();
                    Console.WriteLine("");
                    Console.WriteLine("Digite o ID do lembrete que deseja deletar: ");
                    int op = int.Parse(Console.ReadLine());
                    Eventos.RemoveAll(x => x.ID == op);
                    Console.WriteLine("Lembrete Deletado");
                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadLine();
                    Console.Clear();

                }
            }

        }
    }
}