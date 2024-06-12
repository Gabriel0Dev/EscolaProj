using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;

namespace Escola.Models
{
    public class Menu
    {
        private const string AdminId = "ADMIN";
        private const string AdminSenha = "ADMIN";

        private const string ProfId = "PROF";
        private const string ProfSenha = "PROF";

        private const string AlunoId = "ALUNO";
        private const string AlunoSenha = "ALUNO";
        public static void StartEscola()
        {
            Console.WriteLine("Olá, Seja Bem-Vindo Ao Sistema Escolar!\n[1] - Sou Administrador.\n[2] - Sou Professor. \n[3] - Sou Aluno.\n \n[0] - Finalizar.");
            string opcao = Console.ReadKey().KeyChar.ToString();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    FazerLogin("Admin", AdminId, AdminSenha);
                    break;

                case "2":
                    Console.Clear();
                    MenuProf();
                    break;

                case "3":
                    Console.Clear();
                    MenuAluno();
                    break;

                case "0":
                    Console.WriteLine("Finalizando o Sistema!");
                    Console.ReadKey();
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção Inválida. Retornando Ao Menu.");
                    Console.ReadKey();
                    Console.Clear();
                    StartEscola();
                    break;
            }
        }
        private static void MenuProf()
        {
            Console.WriteLine("Faça o login para continuar. Ou digite SAIR para voltar ao menu.\n \nDigite seu ID.");
            string id = Console.ReadLine();

            if (id.ToLower() == "sair")
            {
                Console.Clear();
                StartEscola();
            }
            else
            {
                Console.Clear();
                FazerLogin("Professor", ProfId, ProfSenha);
                Console.WriteLine("ID invalido. Precione qualquer telca para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                MenuProf();
            }
        }

        private static void MenuAluno()
        {
            Console.WriteLine("Faça o login para continuar. Ou digite SAIR para voltar ao menu.\n \nDigite seu ID.");
            string id = Console.ReadLine();

            if (id.ToLower() == "sair")
            {
                Console.Clear();
                StartEscola();
            }
            else
            {
                MenuAluno();
            }
        }
        private static void FazerLogin(string tipo, string idCorreto, string senhaCorreta)
        {
            Console.WriteLine($"Digite seu ID, {tipo}.");
            string id = Console.ReadLine();

            Console.WriteLine("Digite sua Senha.");
            string senha = Console.ReadLine();

            Console.Clear();

            if (id == idCorreto && senha == senhaCorreta)
            {
                if( tipo == "Admin")
                {
                Console.WriteLine($"SEJA BEM-VINDO DE VOLTA, {tipo.ToUpper()}!");
                Console.ReadKey();
                Console.Clear();
                Administrador.AdmMenuList();
                }
                else if (tipo == "Professor")
                {
                Console.WriteLine($"SEJA BEM-VINDO DE VOLTA, {tipo.ToUpper()}!");
                Console.Clear();
                Menu.StartEscola(); 
                } 
                else if (tipo == "Aluno")
                {
                Console.WriteLine($"SEJA BEM-VINDO DE VOLTA, {tipo.ToUpper()}!");
                Console.Clear();
                Menu.StartEscola();
                }
            }
            else
            {
                Console.WriteLine("ID ou Senha inválida.");
                Console.ReadKey();
                Console.Clear();
                if (tipo == "Admin")
                {
                    StartEscola();
                }
                else if (tipo == "Professor")
                {
                    Menu.MenuProf();
                }
                else if (tipo == "Aluno")
                {
                    Menu.MenuAluno();
                }
            }
        }   
    }
}