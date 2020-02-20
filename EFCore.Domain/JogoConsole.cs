using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class JogoConsole
    {
        public int VideoGameId { get; set; }
        public VideoGame VideoGames { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogos { get; set; }
    }
}
