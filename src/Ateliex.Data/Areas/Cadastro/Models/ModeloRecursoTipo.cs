using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "ModeloRecursoTipo", SingleName = "Tipo de Recurso de Modelo", PluralName = "Tipos de Recurso de Modelo")]
    public class ModeloRecursoTipo : Entity
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Teste: Nome Obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [DisplayName("Custo de Produção")]
        [ReadOnly(true)]
        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        public virtual ObservableCollection<ModeloRecurso> Recursos { get; set; }

        public event NotifyCollectionChangedEventHandler RecursosChanged;
        
        public ModeloRecursoTipo()
        {
            Recursos = new ObservableCollection<ModeloRecurso>();

            Recursos.CollectionChanged += Recursos_CollectionChanged;
        }

        private void Recursos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RecursosChanged?.Invoke(this, e);
        }
    }
}
