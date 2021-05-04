using System;
using System.Text.RegularExpressions;

namespace Poker
{
    enum Cartas
    {
        T = 10,
        Valete = 11,
        Dama = 12,
        Rei = 13,
        As = 14
    }

    public class Utils
    {
        public int tamanhoMao { get; } = 5;

        public string QualCarta(int carta)
        {
            if (carta > 10)
            {
                if (carta == 11)
                    return "Valete";
                else
                if (carta == 12)
                    return "Dama";
                else
                if (carta == 13)
                    return "Rei";
                else
                if (carta == 14)
                    return "Ás";
            }
            return Convert.ToString(carta);
        }

        public bool ehInteiro(string texto)
        {
            if (Regex.IsMatch(texto, @"^[0-9]+$"))
                return true;
            else
                return false;
        }

        public int cartaToInt(string sigla)
        {
            sigla = sigla.ToUpper();
            if (sigla == "T")
                return (int)Cartas.T;
            else if (sigla == "J")
                return (int)Cartas.Valete;
            else if (sigla == "Q")
                return (int)Cartas.Dama;
            else if (sigla == "K")
                return (int)Cartas.Rei;
            else if (sigla == "A")
                return (int)Cartas.As;
            else
                return 0;
        }

        public string QualNaipe(string sigla)
        {
            if (sigla == "D")
                return "Ouro";
            else
            if (sigla == "H")
                return "Copa";
            else
            if (sigla == "S")
                return "Espadas";
            else
            if (sigla == "C")
                return "Paus";
            else
                return "";
        }

        public void ehCartaMaior(ref int valor1, int valor2)
        {
            if (valor1 < valor2)
                valor1 = valor2;
        }
    }
}