using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "ModeloRecursoObservacao", SingleName = "Observação de Recurso de Modelo", PluralName = "Observações de Recurso de Modelo")]
    public class ModeloRecursoObservacao : DataEntity
    {
        public int RecursoId { get; set; }

        [DisplayName("Recurso")]
        public ModeloRecurso Recurso { get; set; }

        public string Texto { get; set; }
    }
}
