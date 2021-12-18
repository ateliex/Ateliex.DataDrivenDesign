using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Comercial.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Areas.Comercial.Models
{
    public class PlanoComercial:Entity
    {
        [Key]
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public decimal RendaBrutaMensal { get; set; }

        public decimal RendaBrutaMensalCalculada
        {
            get
            {
                return 0;
            }
        }

        public decimal CustoFixoTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == PlanoComercialCustoTipo.Fixo).Sum(p => p.Valor);

                return total;
            }
        }

        public decimal CustoFixoPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == PlanoComercialCustoTipo.Fixo).Sum(p => p.PercentualCalculado);

                return total;

                //var percentual = 0m;

                //if (RendaBrutaMensal != 0)
                //{
                //    percentual = CustoFixoTotal / RendaBrutaMensal;
                //}

                //return percentual;
            }
        }

        public decimal CustoVariavelTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == PlanoComercialCustoTipo.Variavel).Sum(p => p.ValorCalculado);

                return total;
            }
        }

        public decimal CustoVariavelPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == PlanoComercialCustoTipo.Variavel).Sum(p => p.Percentual);

                return total;
            }
        }

        public decimal CustoPercentualTotal
        {
            get
            {
                var total = CustoFixoPercentualTotal + CustoVariavelTotal;

                return total;
            }
        }

        public virtual ObservableCollection<PlanoComercialCusto> Custos { get; set; }

        public virtual ObservableCollection<PlanoComercialItem> Itens { get; set; }

        public PlanoComercial()
        {
            Codigo = Guid.NewGuid().ToString();

            Nome = "Plano Comercial #";

            Custos = new ObservableCollection<PlanoComercialCusto>();

            Itens = new ObservableCollection<PlanoComercialItem>();

            PropertyChanged += PlanoComercial_PropertyChanged;

            Custos.CollectionChanged += Custos_CollectionChanged;

            Itens.CollectionChanged += Itens_CollectionChanged;
        }

        private static void PlanoComercial_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var planoComercial = sender as PlanoComercial;

            if (e.PropertyName == nameof(CustoFixoPercentualTotal))
            {
                foreach (var item in planoComercial.Itens)
                {
                    item.OnPropertyChanged("TaxaDeMarcacao");
                }
            }
            else if (e.PropertyName == nameof(CustoVariavelPercentualTotal))
            {
                foreach (var item in planoComercial.Itens)
                {
                    item.OnPropertyChanged("TaxaDeMarcacao");
                }
            }
        }

        private void Custos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var custo = e.NewItems[0] as PlanoComercialCusto;

                custo.PlanoComercial = this;

                var total = Custos.Count;

                //custo.Id = total;
            }
        }

        private void Itens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var item = e.NewItems[0] as PlanoComercialItem;

                item.PlanoComercial = this;

                var total = Itens.Count;

                //item.Id = total;
            }
        }

        public PlanoComercialCusto AdicionaCusto(PlanoComercialCustoTipo tipo, string descricao)
        {
            var model = new PlanoComercialCusto
            {
                PlanoComercial = this,
                Tipo = tipo,
                Descricao = descricao
            };

            Custos.Add(model);

            return model;
        }

        public void RemoveCusto(PlanoComercialCusto custo)
        {
            Custos.Remove(custo);
        }

        public bool ExisteItemDoModelo(Modelo modelo)
        {
            var existe = Itens.Any(p => p.Modelo.Codigo == modelo.Codigo);

            return existe;
        }

        public PlanoComercialItem AdicionaItem(Modelo modelo)
        {
            //var max = Itens.Count;

            //var nextId = max++;

            var model = new PlanoComercialItem
            {
                PlanoComercial = this,
                //Id = nextId,
                Modelo = modelo
            };

            Itens.Add(model);

            return model;
        }

        public void RemoveItem(PlanoComercialItem item)
        {
            Itens.Remove(item);
        }
    }
}
