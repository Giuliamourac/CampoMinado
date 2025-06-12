using System;

class CampoMinado
{
    static void Main(string[] args)
    {

        string[,] celulas =
        {
            { "b", "1", "0", "2", "b", "b", "3", "b", "3", "b"},
            { "2", "2", "0", "2", "b", "4", "3", "b", "3", "1"},
            { "b", "3", "2", "2", "2", "b", "2", "2", "2", "1"},
            { "2", "b", "b", "1", "1", "1", "1", "1", "b", "2"},
            { "3", "4", "3", "1", "0", "1", "1", "1", "2", "b"},
            { "b", "b", "1", "0", "0", "1", "b", "1", "1", "1"},
            { "3", "3", "2", "0", "0", "2", "2", "2", "1", "1"},
            { "1", "b", "1", "0", "1", "3", "b", "2", "2", "b"},
            { "1", "1", "2", "1", "3", "b", "b", "3", "3", "b"},
            { "0", "0", "1", "b", "3", "b", "3", "2", "b", "2"}
        };

        string[,] celulasVisiveis = new string[10, 10];

        Console.WriteLine("Bem vindo ao campo minado! Pressione uma tecla para prosseguir.");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine(@"
        1. Regras
        2. Como Jogar
        3. Sobre
        4. Iniciar");

        
        
    

        Console.WriteLine("");

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.Write( i + " ");
        //
        //    for (int j = 0; j < 10; j++)
        //    {
        //        Console.Write( j + " ");
        //    }
        //}

    }
}