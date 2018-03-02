using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DakiApp.domain.Entities
{
    public class QuestionarioPerguntasDomain : BaseDomain
    {
        [ForeignKey("QuestionariosId")]
        public QuestionariosDomain Questionario { get; set; }
        public int QuestionarioId { get; set; }

        [ForeignKey("PerguntasId")]
        public PerguntasDomain Pergunta { get; set; }
        public int PerguntaId { get; set; }
    }
}