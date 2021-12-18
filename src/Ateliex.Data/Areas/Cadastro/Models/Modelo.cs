using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ateliex.Areas.Cadastro.Models
{
    public class Modelo : Entity
    {
        [Key]
        //[Required(ErrorMessage = "Teste: Código Obrigatório")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        //[Required(ErrorMessage = "Teste: Nome Obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Custo de Produção")]
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
            Codigo = Guid.NewGuid().ToString();

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
