using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.ComponentModel
{
    public abstract class DataEntity : Entity
    {        
        [Required(ErrorMessage = "Teste: Id Obrigatório")]
        public int Id { get; set; }
    }
}
