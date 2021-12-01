using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloRecursoObservacao : DataEntity
    {
        public int RecursoId { get; set; }

        [DisplayName("Recurso")]
        public ModeloRecurso Recurso { get; set; }

        public string Texto { get; set; }
    }
}
