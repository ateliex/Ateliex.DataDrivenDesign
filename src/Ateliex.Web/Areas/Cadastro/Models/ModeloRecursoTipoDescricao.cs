using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloRecursoTipoDescricao : DataEntity
    {
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public ModeloRecursoTipo Tipo { get; set; }

        public string Texto { get; set; }
    }
}
