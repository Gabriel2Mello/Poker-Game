using System.Collections.Generic;

namespace Poker
{
    public class Jogador
    {
        public string nome;
        public List<string> mao = new List<string>(4);
        public List<int> numeroCarta = new List<int>(4);
        public List<string> naipeCarta = new List<string>(4);
        public int cartaAlta = 0;
        public int pesoMao = 0;
        public int cartaMaisAlta = 0;
        public string cartaNaipe = "";
        public string pesoNome = "";
    }
}