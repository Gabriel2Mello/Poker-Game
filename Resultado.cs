using System;
using System.Collections.Generic;

namespace Poker
{
    public class Resultado
    {
        private static Utils utils = new Utils();

        public void facaResultado(Jogador jogador)
        {
            Resultado resultado = new Resultado();
            while (true)
            {
                if (ehRoyalFlush(jogador.numeroCarta, jogador.naipeCarta))
                {
                    jogador.pesoMao = 10;
                    jogador.cartaAlta = 0;
                    jogador.cartaMaisAlta = 0;
                    jogador.pesoNome = "\nRoyal Flush!";
                    break;
                }

                Tuple<bool, int, int> maoJogador1 = new Tuple<bool, int, int>(false, 0, 0);
                maoJogador1 = ehStraightFlush(jogador.numeroCarta, jogador.naipeCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 9;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nStraight Flush!\nCarta mais alta: " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehQuadra(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 8;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nQuadra de " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehFullHouse(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 7;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nFull House\nCom três " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehFlush(jogador.numeroCarta, jogador.naipeCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 6;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nFlush com " + utils.QualNaipe(jogador.naipeCarta[0]);
                    break;
                }

                maoJogador1 = ehStraight(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 5;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nStraigh de" + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehTrinca(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 4;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nTrinca de " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehDoisPares(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 3;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nDois Pares de " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                maoJogador1 = ehUmPar(jogador.numeroCarta);
                if (maoJogador1.Item1 == true)
                {
                    jogador.pesoMao = 2;
                    jogador.cartaAlta = maoJogador1.Item2;
                    jogador.cartaMaisAlta = maoJogador1.Item3;
                    jogador.pesoNome = "\nPar de " + utils.QualCarta(maoJogador1.Item2);
                    break;
                }

                jogador.pesoMao = 1;
                // jogador.cartaAlta = jogador.cartaAlta;
                jogador.cartaMaisAlta = jogador.cartaAlta;
                jogador.pesoNome = "\nCarta mais alta: " + utils.QualCarta(jogador.cartaAlta);
                break;
            }
        }

        public static bool ehNaipeIgual(List<string> naipeCarta)
        {
            if ((naipeCarta[0] == naipeCarta[1]) &&
                (naipeCarta[0] == naipeCarta[2]) &&
                (naipeCarta[0] == naipeCarta[3]) &&
                (naipeCarta[0] == naipeCarta[4]))
                return true;

            return false;
        }

        public static bool ehNumeroConsecutivo(List<int> numeroCarta)
        {
            if ((numeroCarta[0] + 1 == numeroCarta[1]) &&
                (numeroCarta[1] + 1 == numeroCarta[2]) &&
                (numeroCarta[2] + 1 == numeroCarta[3]) &&
                (numeroCarta[3] + 1 == numeroCarta[4]))
                return true;
            else
                return false;
        }

        public static bool ehRoyalFlush(List<int> numeroCarta, List<string> naipeCarta)
        {
            if (((numeroCarta[0] == (int)Cartas.T) &&
                 (numeroCarta[1] == (int)Cartas.Valete) &&
                 (numeroCarta[2] == (int)Cartas.Dama) &&
                 (numeroCarta[3] == (int)Cartas.Rei) &&
                 (numeroCarta[4] == (int)Cartas.As)) && (ehNaipeIgual(naipeCarta)))
                return true;
            return false;
        }

        public static Tuple<bool, int, int> ehStraightFlush(List<int> numeroCarta, List<string> naipeCarta)
        {
            if (ehNumeroConsecutivo(numeroCarta) && (ehNaipeIgual(naipeCarta)))
            {
                int maiorCarta = 0;
                foreach (int numero in numeroCarta)
                    utils.ehCartaMaior(ref maiorCarta, numero);

                return new Tuple<bool, int, int>(true, maiorCarta, maiorCarta);
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehQuadra(List<int> numeroCarta)
        {
            int contador = 0;
            int cartaMaior = 0;
            int quadraMaior = 0;
            for (int i = 0; i < utils.tamanhoMao; i++)
            {
                for (int j = 1; j < utils.tamanhoMao; j++)
                {
                    if (numeroCarta[i] == numeroCarta[j])
                    {
                        contador++;
                        i++;
                        utils.ehCartaMaior(ref cartaMaior, numeroCarta[i]);
                    }
                    else
                    {
                        quadraMaior = numeroCarta[i];
                        i++;
                        contador = 0;
                    }
                    if (contador == 3)
                        return new Tuple<bool, int, int>(true, cartaMaior, quadraMaior);
                }
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehFullHouse(List<int> numeroCarta)
        {
            int contador = 0;
            int contador1 = 0;
            int trincaMaior = 0;
            for (int i = 0; i < utils.tamanhoMao; i++)
            {
                for (int k = 1; k < utils.tamanhoMao; k++)
                {
                    if (numeroCarta[i] == numeroCarta[k])
                    {
                        contador++;
                        i++;
                        if ((contador == 2) && (trincaMaior < numeroCarta[i]))
                            trincaMaior = numeroCarta[i];
                    }
                    else
                        break;
                }

                int j = i + 1;
                while (j < utils.tamanhoMao)
                {
                    if (i < utils.tamanhoMao)
                    {
                        if (numeroCarta[i] == numeroCarta[j])
                        {
                            contador1++;
                            i++;

                            if ((contador1 == 2) && (trincaMaior < numeroCarta[i]))
                                trincaMaior = numeroCarta[i];

                            if ((contador == 2) && (contador1 == 1) || (contador == 1) && (contador1 == 2))
                                return new Tuple<bool, int, int>(true, trincaMaior, trincaMaior);
                        }
                    }
                    j++;
                }
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehFlush(List<int> numeroCarta, List<string> naipeCarta)
        {
            if (ehNaipeIgual(naipeCarta))
            {
                int maiorCarta = 0;
                foreach (int numero in numeroCarta)
                    utils.ehCartaMaior(ref maiorCarta, numero);

                return new Tuple<bool, int, int>(true, maiorCarta, maiorCarta);
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehStraight(List<int> numeroCarta)
        {
            if (ehNumeroConsecutivo(numeroCarta))
            {
                int maiorCarta = 0;
                foreach (int numero in numeroCarta)
                    utils.ehCartaMaior(ref maiorCarta, numero);

                return new Tuple<bool, int, int>(true, maiorCarta, maiorCarta);
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehTrinca(List<int> numeroCarta)
        {
            int contador = 0;
            int valorTrinca = 0;
            int cartaMaior = 0;
            for (int i = 0; i < utils.tamanhoMao; i++)
            {
                for (int j = 1; j < utils.tamanhoMao; j++)
                {
                    if (numeroCarta[i] == numeroCarta[j])
                    {
                        contador++;
                        i++;
                        utils.ehCartaMaior(ref valorTrinca, numeroCarta[i]);

                        if (contador == 2)
                            return new Tuple<bool, int, int>(true, valorTrinca, cartaMaior);
                    }
                    else
                    {
                        utils.ehCartaMaior(ref cartaMaior, numeroCarta[i]);
                        contador = 0;
                        i++;
                    }
                }
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehDoisPares(List<int> numeroCarta)
        {
            int contador = 0;
            int parMaior = 0;
            int cartaMaior = 0;
            int i = 0;
            for (int j = 1; j < utils.tamanhoMao; j++)
            {
                if (numeroCarta[i] == numeroCarta[j])
                {
                    contador++;
                    utils.ehCartaMaior(ref parMaior, numeroCarta[i]);

                    if ((contador == 2))
                        return new Tuple<bool, int, int>(true, parMaior, cartaMaior);
                }
                else
                    utils.ehCartaMaior(ref cartaMaior, numeroCarta[i]);
                i++;
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public static Tuple<bool, int, int> ehUmPar(List<int> numeroCarta)
        {
            int contador = 0;
            int parMaior = 0;
            int cartaMaior = 0;
            for (int i = 0; i < utils.tamanhoMao; i++)
            {
                for (int j = 1; j < utils.tamanhoMao; j++)
                {
                    if (numeroCarta[i] == numeroCarta[j])
                    {
                        contador++;
                        utils.ehCartaMaior(ref parMaior, numeroCarta[i]);
                    }
                    else
                        utils.ehCartaMaior(ref cartaMaior, numeroCarta[i]);

                    if (contador == 1)
                        return new Tuple<bool, int, int>(true, parMaior, cartaMaior);
                    i++;
                }
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public string calculaResultado(Jogador jogador1, Jogador jogador2)
        {
            separaCartas(jogador1);
            separaCartas(jogador2);
            facaResultado(jogador1);
            facaResultado(jogador2);

            string vencedor1 = "Vencedor: " + jogador1.nome + jogador1.pesoNome;
            string vencedor2 = "Vencedor: " + jogador2.nome + jogador2.pesoNome;

            if (jogador1.pesoMao == 10)
                return vencedor1;
            else
            if (jogador2.pesoMao == 10)
                return vencedor2;

            if ((jogador1.pesoMao > jogador2.pesoMao))
                return vencedor1;
            else
            if ((jogador1.pesoMao == jogador2.pesoMao) && (jogador1.cartaAlta > jogador2.cartaAlta))
                return vencedor1;
            else
            if ((jogador1.pesoMao == jogador2.pesoMao) && (jogador1.cartaAlta == jogador2.cartaAlta) && (jogador1.cartaMaisAlta > jogador2.cartaMaisAlta))
                return vencedor1 + "\nCarta mais alta: " + utils.QualCarta(jogador1.cartaMaisAlta);
            else
            if ((jogador2.pesoMao > jogador1.pesoMao))
                return vencedor2;
            else
            if ((jogador2.pesoMao == jogador1.pesoMao) && (jogador2.cartaAlta > jogador1.cartaAlta))
                return vencedor2;
            else
            if ((jogador2.pesoMao == jogador1.pesoMao) && (jogador2.cartaAlta == jogador1.cartaAlta) && (jogador2.cartaMaisAlta > jogador1.cartaMaisAlta))
                return vencedor2 + "\nCarta mais alta: " + utils.QualCarta(jogador2.cartaMaisAlta);
            else
            if (jogador1.cartaMaisAlta > jogador2.cartaMaisAlta)
                return vencedor1;
            else
                return vencedor2;
        }
        public void separaCartas(Jogador jogador)
        {
            Utils utils = new Utils();
            for (int i = 0; i < utils.tamanhoMao; i++)
            {
                string cartaCrua = jogador.mao[i].Substring(0, 1);
                if (utils.ehInteiro(cartaCrua))
                    jogador.numeroCarta.Add((Convert.ToInt32(cartaCrua)));
                else
                    jogador.numeroCarta.Add((utils.cartaToInt(cartaCrua)));

                jogador.naipeCarta.Add((jogador.mao[i].Substring(1)).ToUpper());
                utils.ehCartaMaior(ref jogador.cartaAlta, jogador.numeroCarta[i]);
            }
        }

    }
}
