using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Models
{
    public class Modelo
    {
        [Key]
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        public virtual ICollection<Recurso> Recursos { get; set; }

        public Modelo()
        {
            Recursos = new HashSet<Recurso>();
        }
    }

    public enum TipoDeRecurso
    {
        Material,
        Transporte,
        Humano
    }

    public class Recurso
    {
        public virtual Modelo Modelo { get; set; }

        public virtual TipoDeRecurso Tipo { get; set; }

        public virtual string Descricao { get; set; }

        public decimal Custo { get; set; }

        public int Unidades { get; set; }

        public decimal CustoPorUnidade
        {
            get
            {
                var custoPorUnidade = Custo / Unidades;

                return custoPorUnidade;
            }
        }

        public Recurso()
        {

        }

        public string ModeloCodigo { get; set; }
    }

    public interface IRepositorioDeModelos
    {
        Task<Modelo> ObtemModelo(string id);

        Task Add(Modelo modelo);

        Task Update(Modelo modelo);

        Task Remove(Modelo modelo);
    }
}
