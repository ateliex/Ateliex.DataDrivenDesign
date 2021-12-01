using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "ModeloRecursoTipos", SingleName = "Modelo Recurso Tipo", PluralName = "Modelo Recurso Tipos", ChildEntities = new string[] { })]
    public class ModeloRecursoTipo : DataEntity
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Teste: Nome Obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public ModeloRecursoTipoDescricao Descricao { get; set; }
    }
}
