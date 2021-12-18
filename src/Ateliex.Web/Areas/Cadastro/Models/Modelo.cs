using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "Modelo", SingleName = "Modelo", PluralName = "Modelos")]
    public class Modelo : DataEntity
    {
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

        public Modelo()
        {
            //Id = -1;

            Nome = "Modelo #";

            Recursos = new ObservableCollection<ModeloRecurso>();

            Recursos.CollectionChanged += Recursos_CollectionChanged;
        }

        private void Recursos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RecursosChanged?.Invoke(this, e);
        }
    }
}
