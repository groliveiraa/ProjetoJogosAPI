using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Domain
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<JogoConsole> JogosConsoles { get; set; }

        [ForeignKey("Generos")]
        public int GeneroId { get; set; }
        public virtual Genero Generos { get; set; }

        [ForeignKey("Classificacoes")]
        public int ClassificacaoId { get; set; }
        public virtual ClassificacaoIndicativa Classificacoes { get; set; }

        public DateTime DtCadastro { get; set; }
    }
}
