using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloRecursoAnexo : DataEntity
    {
        public int RecursoId { get; set; }

        [DisplayName("Recurso")]
        public ModeloRecurso Recurso { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        public byte[] Arquivo { get; set; }
    }
}
