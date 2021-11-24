using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ateliex.Models
{
    public class Modelo : Entity
    {
        [Key]
        [Required(ErrorMessage = "Teste: Código Obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Teste: Nome Obrigatório")]
        public string Nome { get; set; }

        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        public virtual ObservableCollection<Recurso> Recursos { get; set; }

        public event NotifyCollectionChangedEventHandler RecursosChanged;

        public Modelo()
        {
            Codigo = Guid.NewGuid().ToString();

            Nome = "Modelo #";

            Recursos = new ObservableCollection<Recurso>();

            Recursos.CollectionChanged += Recursos_CollectionChanged;
        }

        private void Recursos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RecursosChanged?.Invoke(this, e);
        }
    }

    public class Recurso : Entity
    {
        public virtual Modelo Modelo { get; set; }

        public int Id { get; set; }

        public TipoDeRecurso Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Custo { get; set; }

        public int Unidades { get; set; }

        public decimal CustoPorUnidade
        {
            get
            {
                if (Unidades == 0)
                {
                    return 0;
                }
                else
                {
                    var custoPorUnidade = Custo / Unidades;

                    return custoPorUnidade;
                }
            }
        }

        public Recurso()
        {
            PropertyChanged += Recurso_PropertyChanged;
        }

        private static void Recurso_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var recurso = sender as Recurso;

            if (recurso.Modelo == null) return;

            if (e.PropertyName == nameof(CustoPorUnidade))
            {
                recurso.Modelo.OnPropertyChanged("CustoDeProducao");
            }
        }

        public string ModeloCodigo { get; set; }
    }

    public enum TipoDeRecurso
    {
        Material,
        Transporte,
        Humano
    }
}
