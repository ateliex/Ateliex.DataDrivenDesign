using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [DataInfo(AreaName = "Cadastro", MetaName = "ModeloRecursos", SingleName = "Modelo Recurso", PluralName = "Modelo Recursos", ChildEntities = new string[] { })]
    public class ModeloRecurso : DataEntity
    {
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }

        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public ModeloRecursoTipo Tipo { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [DisplayName("Custo")]
        public decimal Custo { get; set; }

        [DisplayName("Unidades")]
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

        [DisplayName("Observação")]
        public ModeloRecursoObservacao Observacao { get; set; }

        public virtual ObservableCollection<ModeloRecursoAnexo> Anexos { get; set; }

        public event NotifyCollectionChangedEventHandler AnexosChanged;

        public ModeloRecurso()
        {
            PropertyChanged += Recurso_PropertyChanged;

            Anexos = new ObservableCollection<ModeloRecursoAnexo>();

            Anexos.CollectionChanged += Anexos_CollectionChanged;
        }

        private static void Recurso_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var recurso = sender as ModeloRecurso;

            if (recurso.Modelo == null) return;

            if (e.PropertyName == nameof(CustoPorUnidade))
            {
                recurso.Modelo.OnPropertyChanged("CustoDeProducao");
            }
        }

        private void Anexos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            AnexosChanged?.Invoke(this, e);
        }
    }
}
