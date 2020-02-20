using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<JogoConsole> JogosConsoles { get; set; }
        public int GeneroId { get; set; }
        public int ClassificacaoId { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
