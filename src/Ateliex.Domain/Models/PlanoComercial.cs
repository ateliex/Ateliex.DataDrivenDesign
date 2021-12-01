using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ateliex.Models
{
    public class PlanoComercial : DataEntity
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
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Fixo).Sum(p => p.Valor);

                return total;
            }
        }

        public decimal CustoFixoPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Fixo).Sum(p => p.PercentualCalculado);

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
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Variavel).Sum(p => p.ValorCalculado);

                return total;
            }
        }

        public decimal CustoVariavelPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Variavel).Sum(p => p.Percentual);

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

        public virtual ObservableCollection<Custo> Custos { get; set; }

        public virtual ObservableCollection<ItemDePlanoComercial> Itens { get; set; }

        public PlanoComercial()
        {
            Codigo = Guid.NewGuid().ToString();

            Nome = "Plano Comercial #";

            Custos = new ObservableCollection<Custo>();

            Itens = new ObservableCollection<ItemDePlanoComercial>();

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
                var custo = e.NewItems[0] as Custo;

                custo.PlanoComercial = this;

                var total = Custos.Count;

                //custo.Id = total;
            }
        }

        private void Itens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var item = e.NewItems[0] as ItemDePlanoComercial;

                item.PlanoComercial = this;

                var total = Itens.Count;

                //item.Id = total;
            }
        }

        public Custo AdicionaCusto(TipoDeCusto tipo, string descricao)
        {
            var model = new Custo
            {
                PlanoComercial = this,
                Tipo = tipo,
                Descricao = descricao
            };

            Custos.Add(model);

            return model;
        }

        public void RemoveCusto(Custo custo)
        {
            Custos.Remove(custo);
        }

        public bool ExisteItemDoModelo(Modelo modelo)
        {
            var existe = Itens.Any(p => p.Modelo.Codigo == modelo.Codigo);

            return existe;
        }

        public ItemDePlanoComercial AdicionaItem(Modelo modelo)
        {
            //var max = Itens.Count;

            //var nextId = max++;

            var model = new ItemDePlanoComercial
            {
                PlanoComercial = this,
                //Id = nextId,
                Modelo = modelo
            };

            Itens.Add(model);

            return model;
        }

        public void RemoveItem(ItemDePlanoComercial item)
        {
            Itens.Remove(item);
        }
    }

    public class Custo : Entity
    {
        public PlanoComercial PlanoComercial { get; set; }

        public int Id { get; set; }

        public TipoDeCusto Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal Percentual { get; set; }

        public decimal ValorCalculado
        {
            get
            {
                if (Tipo == TipoDeCusto.Fixo)
                {
                    return Valor;
                }
                else if (Tipo == TipoDeCusto.Variavel)
                {
                    var valorCalculado = (PlanoComercial.RendaBrutaMensal * Percentual) / 100;

                    return valorCalculado;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        public decimal PercentualCalculado
        {
            get
            {
                if (Tipo == TipoDeCusto.Fixo)
                {
                    var percentualCalculado = 0m;

                    if (PlanoComercial.RendaBrutaMensal != 0)
                    {
                        percentualCalculado = (Valor / PlanoComercial.RendaBrutaMensal) * 100;
                    }

                    return percentualCalculado;
                }
                else if (Tipo == TipoDeCusto.Variavel)
                {
                    return Percentual;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        public Custo()
        {
            PropertyChanged += Custo_PropertyChanged;
        }

        private static void Custo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var custo = sender as Custo;

            if (custo.PlanoComercial == null) return;

            if (e.PropertyName == nameof(Valor))
            {
                custo.PlanoComercial.OnPropertyChanged("CustoFixoTotal");
            }
            else if (e.PropertyName == nameof(Percentual))
            {
                custo.PlanoComercial.OnPropertyChanged("CustoVariavelPercentualTotal");
            }
            else if (e.PropertyName == nameof(ValorCalculado))
            {
                custo.PlanoComercial.OnPropertyChanged("CustoVariavelTotal");
            }
            else if (e.PropertyName == nameof(PercentualCalculado))
            {
                custo.PlanoComercial.OnPropertyChanged("CustoFixoPercentualTotal");
            }
        }

        public string PlanoComercialCodigo { get; set; }
    }

    public enum TipoDeCusto
    {
        Fixo,
        Variavel,
    }

    public class ItemDePlanoComercial : Entity
    {
        //private PlanoComercial planoComercial;

        public PlanoComercial PlanoComercial { get; set; }
        //{
        //    get { return planoComercial; }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            if (planoComercial != null)
        //            {
        //                planoComercial.PropertyChanged -= PlanoComercial_PropertyChanged;
        //            }
        //        }

        //        planoComercial = value;

        //        if (planoComercial != null)
        //        {
        //            planoComercial.PropertyChanged += PlanoComercial_PropertyChanged;
        //        }
        //    }
        //}

        //private void PlanoComercial_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    var planoComercial = sender as PlanoComercial;

        //    if (e.PropertyName == "CustoFixoPercentualTotal")
        //    {
        //        OnPropertyChanged(nameof(TaxaDeMarcacao));
        //    }
        //    else if (e.PropertyName == "CustoVariavelPercentualTotal")
        //    {
        //        OnPropertyChanged(nameof(TaxaDeMarcacao));
        //    }
        //}

        private Modelo modelo;

        public Modelo Modelo
        {
            get { return modelo; }
            set
            {
                if (value == null)
                {
                    if (modelo != null)
                    {
                        modelo.PropertyChanged -= Modelo_PropertyChanged;
                    }
                }

                modelo = value;

                if (modelo != null)
                {
                    modelo.PropertyChanged += Modelo_PropertyChanged;
                }
            }
        }

        private void Modelo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var modelo = sender as Modelo;

            if (e.PropertyName == "CustoDeProducao")
            {
                OnPropertyChanged(nameof(CustoDeProducao));
            }
        }

        public decimal CustoDeProducao { get { return Modelo.CustoDeProducao; } }

        public decimal? CustoDeProducaoSugerido
        {
            get
            {
                var custo = 0m;

                if (PrecoDeVendaDesejado.HasValue && CustoDeProducao != 0)
                {
                    custo = PrecoDeVendaDesejado.Value / CustoDeProducao;
                }

                return custo;
            }
        }

        public decimal Margem { get; set; }

        public decimal MargemPercentual { get; set; }

        public decimal MargemCalculada
        {
            get
            {
                var valor = MargemPercentual * PlanoComercial.RendaBrutaMensal;

                return valor;
            }
        }

        public decimal MargemPercentualCalculada
        {
            get
            {
                return 0;
            }
        }

        public decimal TaxaDeMarcacao
        {
            get
            {
                return 100 / (100 - (PlanoComercial.CustoFixoPercentualTotal + PlanoComercial.CustoVariavelPercentualTotal + MargemPercentual));
            }
        }

        public decimal? TaxaDeMarcacaoSugerida { get; set; }

        public decimal PrecoDeVenda
        {
            get
            {
                decimal precoDeVenda;

                var taxaDeMarcacao = TaxaDeMarcacao;

                var custoDeProducao = CustoDeProducao;

                ///////////////////////////////////////////////////
                precoDeVenda = taxaDeMarcacao * custoDeProducao; //
                ///////////////////////////////////////////////////

                return precoDeVenda;
            }
        }

        public decimal? PrecoDeVendaDesejado { get; set; }

        public ItemDePlanoComercial()
        {
            PropertyChanged += ItemDePlanoComercial_PropertyChanged;
        }

        private static void ItemDePlanoComercial_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var item = sender as ItemDePlanoComercial;

            if (item.PlanoComercial == null) return;

            if (e.PropertyName == nameof(TaxaDeMarcacao))
            {
                item.OnPropertyChanged(nameof(PrecoDeVenda));
            }
            //if (e.PropertyName == nameof(MargemPercentual))
            //{
            //    item.OnPropertyChanged(nameof(TaxaDeMarcacao));
            //}
            //else if (e.PropertyName == nameof(PercentualCalculado))
            //{
            //    item.PlanoComercial.OnPropertyChanged("CustoFixoPercentualTotal");
            //}
        }

        public string PlanoComercialCodigo { get; set; }

        public string ModeloCodigo { get; set; }
    }
}
