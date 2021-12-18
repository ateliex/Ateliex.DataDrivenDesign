using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloRecurso : Entity
    {
        [DisplayName("Modelo")]
        public string ModeloCodigo { get; set; }

        [DisplayName("Modelo")]
        public virtual Modelo? Modelo { get; set; }

        public int Id { get; set; }

        [DisplayName("Tipo")]
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public virtual ModeloRecursoTipo? Tipo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Custo")]
        public decimal Custo { get; set; }

        [DisplayName("Unidades")]
        public int Unidades { get; set; }
        
        [DisplayName("Custo por Unidade")]
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

        public ModeloRecurso()
        {
            PropertyChanged += Recurso_PropertyChanged;
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
    }
}
