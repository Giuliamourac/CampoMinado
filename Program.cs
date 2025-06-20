using System;
using System.ComponentModel.DataAnnotations.Schema;
public class CampoMinado
{
    public static void Main(string[] args)
    {
        bool continuarMenu = true;

        while (continuarMenu)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("--- Campo Minado ---");
            Console.ResetColor();

            Console.WriteLine(@"
    Digite o número da opção:
    1. Regras
    2. Sobre
    3. Como Jogar
    4. Iniciar Jogo
    5. Sair
    ");
            
            Console.Write("Sua escolha: ");
            bool entradaValida = int.TryParse(Console.ReadLine(), out int opcao);
            
            if (entradaValida)
            {
                switch (opcao)
                {
                    case 1:
                        ExibirRegras();
                        break;
                    case 2:
                        ExibirSobre();
                        break;
                    case 3:
                        ExibirComoJogar();
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\nIniciando o Jogo de Campo Minado...");
                        Console.ResetColor();

                        IniciarJogo();

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\nO jogo foi encerrado. Pressione qualquer tecla para voltar ao menu.");
                        Console.ResetColor();

                        Console.ReadKey();
                        break;
                    case 5:
                        continuarMenu = false;
                        Console.WriteLine("\nSaindo do Campo Minado. Até a próxima!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Por favor, digite um número de 1 a 5.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }


    public static void ExibirRegras()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("--- Regras do Jogo de Campo Minado ---");
        Console.ResetColor();

        Console.WriteLine("1. O objetivo é **revelar todas as células que não contêm minas**.");
        Console.WriteLine("2. Se você **escolher uma mina**, o jogo termina e você perde.");
        Console.WriteLine("3. Ao escolher uma célula segura, ela pode revelar um **número** ou ficar vazia.");
        Console.WriteLine("4. Um **número** indica quantas minas estão diretamente adjacentes (ao lado, na diagonal) a essa célula.");
        Console.WriteLine("5. Você **ganha** quando todas as células sem minas são reveladas.");

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ResetColor();

        Console.ReadKey();
    }

    public static void ExibirSobre()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("--- Sobre o Campo Minado ---");
        Console.ResetColor();

        Console.WriteLine("Este é um jogo de Campo Minado simples, implementado em C#.");
        Console.WriteLine("Versão: 1.0 (Menu de Console)");
        Console.WriteLine("Desenvolvido por: Andreh Marques Gonçalves");
        Console.WriteLine("Desenvolvido por: Gabriel Nunes da Costa Anselmo");
        Console.WriteLine("Desenvolvido por: Giulia de Moura Carnevale");
        Console.WriteLine("Inspirado no clássico jogo de lógica e dedução.");
        Console.WriteLine("\nDivirta-se!");

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ResetColor();

        Console.ReadKey();
    }

    public static void ExibirComoJogar()
    {
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("--- Como Jogar Campo Minado ---");
        Console.ResetColor();

        Console.WriteLine("1. **Estratégia:** Use os números revelados para deduzir onde as minas **não** estão, e onde elas **estão**.");
        Console.WriteLine("2. Utilize coordenadas, linha e colunas, para selecionar uma célula");
        Console.WriteLine("\nBoa sorte e divirta-se desarmando o campo!");

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ResetColor();

        Console.ReadKey();
    }

    public static void ExibirTabuleiro(char[,] celulas, bool[,] revelado)

    {
        Console.Clear();

        Console.Write("   ");
        Console.ForegroundColor = ConsoleColor.Red;
        for (int j = 0; j < 10; j++)
        {
            Console.Write(j + " ");
        }
        Console.WriteLine();

       for (int i = 0; i < 10; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(i + "  ");
            Console.ResetColor();
            for (int j = 0; j < 10; j++)
            {
                if (revelado[i, j])
                {
                    Console.Write(celulas[i, j] + " ");
                }
                else
                {
                
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }
    public static void IniciarJogo()

    {

        bool jogoAtivo = true;
        bool[,] revelado = new bool[10, 10];
        int linha = 0;
        int coluna = 0;

        Console.Clear();

        char[,] celulas =
        {
            { 'b', '1', '0', '2', 'b', 'b', '3', 'b', '3', 'b' },
            { '2', '2', '0', '2', 'b', '4', '3', 'b', '3', '1' },
            { 'b', '3', '2', '2', '2', 'b', '2', '2', '2', '1' },
            { '2', 'b', 'b', '1', '1', '1', '1', '1', 'b', '2' },
            { '3', '4', '3', '1', '0', '1', '1', '1', '2', 'b' },
            { 'b', 'b', '1', '0', '0', '1', 'b', '1', '1', '1' },
            { '3', '3', '2', '0', '0', '2', '2', '2', '1', '1' },
            { '1', 'b', '1', '0', '1', '3', 'b', '2', '2', 'b' },
            { '1', '1', '2', '1', '3', 'b', 'b', '3', '3', 'b' },
            { '0', '0', '1', 'b', '3', 'b', '3', '2', 'b', '2' }
        };

        ExibirTabuleiro(celulas, revelado);

        while (jogoAtivo)
        {
            Console.Write("Digite uma linha (0-9):");
            while (!int.TryParse(Console.ReadLine()!, out linha) || linha < 0 || linha > 9)
            {
                Console.WriteLine("Numero de linha invalido, digite novamente:");
            }

            Console.Write("Digite uma coluna (0-9):");
            while (!int.TryParse(Console.ReadLine()!, out coluna) || coluna < 0 || coluna > 9)
            {
                Console.WriteLine("Numero de coluna invalido, digite novamente:");
            }

            if (celulas[linha, coluna] == 'b')
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(@"--FIM DE JOGO--
                Uma bomba foi destruida");
                Console.ResetColor();

                jogoAtivo = false;
            }
            else
            {
                revelado[linha, coluna] = true;

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Continue Jogando...");
                Console.ResetColor();

                ExibirTabuleiro(celulas, revelado);

                Thread.Sleep(1000);
            }
        }
    }
}