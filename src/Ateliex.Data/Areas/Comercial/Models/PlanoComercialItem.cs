using Ateliex.Areas.Cadastro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Areas.Comercial.Models
{
    public class PlanoComercialItem : Entity
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

        public PlanoComercialItem()
        {
            PropertyChanged += PlanoComercialItem_PropertyChanged;
        }

        private static void PlanoComercialItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var item = sender as PlanoComercialItem;

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
