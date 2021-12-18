using Ateliex.Areas.Comercial.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Areas.Comercial.Models
{
    public class PlanoComercialCusto:Entity
    {
        public PlanoComercial PlanoComercial { get; set; }

        public int Id { get; set; }

        public PlanoComercialCustoTipo Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal Percentual { get; set; }

        public decimal ValorCalculado
        {
            get
            {
                if (Tipo == PlanoComercialCustoTipo.Fixo)
                {
                    return Valor;
                }
                else if (Tipo == PlanoComercialCustoTipo.Variavel)
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
                if (Tipo == PlanoComercialCustoTipo.Fixo)
                {
                    var percentualCalculado = 0m;

                    if (PlanoComercial.RendaBrutaMensal != 0)
                    {
                        percentualCalculado = (Valor / PlanoComercial.RendaBrutaMensal) * 100;
                    }

                    return percentualCalculado;
                }
                else if (Tipo == PlanoComercialCustoTipo.Variavel)
                {
                    return Percentual;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        public PlanoComercialCusto()
        {
            PropertyChanged += Custo_PropertyChanged;
        }

        private static void Custo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var custo = sender as PlanoComercialCusto;

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
}
