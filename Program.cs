using System;

namespace Poker
{
    class Program
    {
        const int tamanhoMao = 5;
        static void Main(string[] args)
        {
            Desafio();
        }

        public static void Desafio()
        {
            Console.Clear();
            Jogador jogador1 = new Jogador();
            Jogador jogador2 = new Jogador();
            // jogador1.nome = "Jogador 1";
            // jogador1.mao.Add("2D");
            // jogador1.mao.Add("9C");
            // jogador1.mao.Add("AS");
            // jogador1.mao.Add("AH");
            // jogador1.mao.Add("AC");

            // jogador2.nome = "Jogador 2";
            // jogador2.mao.Add("3D");
            // jogador2.mao.Add("6D");
            // jogador2.mao.Add("7D");
            // jogador2.mao.Add("TH");
            // jogador2.mao.Add("QD");

            Console.Write("Nome do Jogador 1: ");
            jogador1.nome = Console.ReadLine();
            if (jogador1.nome == "")
                jogador1.nome = "Jogador 1";
            Console.Clear();

            Console.Write("Nome do Jogador 2: ");
            jogador2.nome = Console.ReadLine();
            if (jogador2.nome == "")
                jogador2.nome = "Jogador 2";
            Console.Clear();

            for (int i = 0; i < tamanhoMao; i++)
            {
                Console.WriteLine(jogador1.nome);
                Console.Write($"Carta {i + 1}: ");
                jogador1.mao.Add(Console.ReadLine().ToUpper());
                Console.Clear();

                Console.WriteLine(jogador2.nome);
                Console.Write($"Carta {i + 1}: ");
                jogador2.mao.Add(Console.ReadLine().ToUpper());
                Console.Clear();
            }

            Resultado resultado = new Resultado();

            Console.WriteLine(resultado.calculaResultado(jogador1, jogador2));
            VoltarDesafio();
        }
        public static void VoltarDesafio()
        {
            Console.Write("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Desafio();
        }
    }
}