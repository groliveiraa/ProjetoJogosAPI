using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Jogo> Jogos { get; set; }
        public List<JogoConsole> JogosConsoles { get; set; }
    }
}
