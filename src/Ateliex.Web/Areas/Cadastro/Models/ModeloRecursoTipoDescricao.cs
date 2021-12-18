using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "ModeloRecursoTipoDescricao", SingleName = "Descrição de Tipo de Recurso de Modelo", PluralName = "Descrições de Tipo de Recurso de Modelo")]
    public class ModeloRecursoTipoDescricao : DataEntity
    {
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public ModeloRecursoTipo Tipo { get; set; }

        public string Texto { get; set; }
    }
}
