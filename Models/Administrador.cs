using System;
using System.Collections.Generic;

namespace Escola.Models
{
    public class Administrador
    {
        // !
        //                          !Professor                           //
        private static List<string> ListaProfessores = new List<string>();

        public static void AdmMenuList()
        {
            Console.WriteLine("[1] - Adicionar Professor.\n[2] - Exibir Lista de Professores.\n[3] - ...\n\n[0] - Fazer LogOff.");
            string opcao = Console.ReadKey().KeyChar.ToString();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    AdicionarProfessor();
                    break;

                case "2":
                    Console.Clear();
                    ExibirLista(ListaProfessores);
                    Console.ReadKey();
                    Console.Clear();
                    AdmMenuList();
                    break;

                case "3":
                    Console.Clear();
                    AdmMenuList();
                    break;

                case "0":
                    Console.WriteLine("LogOff realizado com sucesso!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.StartEscola();
                    break;

                default:
                    Console.WriteLine("Opção Inválida. Retornando Ao Menu.");
                    Console.ReadKey();
                    Console.Clear();
                    AdmMenuList();
                    break;
            }
        }

        private static void AdicionarProfessor()
        {
            for (int i = 0;; i++)
            {
                Console.WriteLine($"Digite o nome do professor {i + 1} (digite 'Sair' para encerrar):");
                string nome;

                if ((nome = Console.ReadLine().ToLower()) == "sair")
                {
                    Console.Clear();
                    Console.WriteLine("Salvando dados...");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirLista(ListaProfessores);
                    Console.ReadKey();
                    Console.Clear();
                    AdmMenuList();
                    break;
                }

                while (!VerificarNome(nome))
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, digite um nome válido (sem números):");
                    nome = Console.ReadLine();
                }

                Console.WriteLine($"Digite o CRE do professor {nome}:");
                int cre;

                while (!int.TryParse(Console.ReadLine(), out cre))
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, digite um CRE válido (número inteiro):");
                }

                Console.WriteLine($"Digite o número de celular do professor {nome}:");

                string celular;
                while (true)
                {
                    celular = Console.ReadLine();
                    if (VerificarNumeroCelular(celular))
                    {
                        break;
                    }
                    Console.WriteLine("Por favor, digite um número de celular válido:");
                }

                ListaProfessores.Add($"Nome: {nome}, CRE: {cre}, Celular: {celular}");
            }
        }

        private static void ExibirLista(List<string> lista)
        {
            Console.WriteLine("\nLista de Professores:");

            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }
        }

        private static bool VerificarNumeroCelular(string numero)
        {
            foreach (char c in numero)
            {
                if (!char.IsDigit(c) && c != '-' && c != '(' && c != ')' && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool VerificarNome(string nome)
        {
            foreach (char c in nome)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}