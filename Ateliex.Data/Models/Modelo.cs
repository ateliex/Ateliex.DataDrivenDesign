using Ateliex.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ateliex.Models
{
    public class Modelo : Entity
    {
        [Key]
        private string codigo;
        [Required(ErrorMessage = "Teste: Código Obrigatório")]
        public string Codigo
        {
            get { return codigo; }
            set
            {
                try
                {
                    codigo = value;

                    OnPropertyChanged();

                    ClearErrors("Codigo");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("Codigo", ex);
                }
            }
        }

        private string nome;
        [Required(ErrorMessage = "Teste: Nome Obrigatório")]
        public string Nome
        {
            get { return nome; }
            set
            {
                try
                {
                    nome = value;

                    OnPropertyChanged();

                    ClearErrors("Nome");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("Nome", ex);
                }
            }
        }

        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        public virtual RecursosCollection Recursos { get; set; }

        public Modelo()
        {
            Codigo = Guid.NewGuid().ToString();

            Nome = "Modelo #";

            Recursos = new RecursosCollection(new List<Recurso>() { });

            Recursos.modelo = this;
        }
    }

    public class Recurso : Entity
    {
        public virtual Modelo Modelo { get; set; }

        private TipoDeRecurso tipo;
        public TipoDeRecurso Tipo
        {
            get { return tipo; }
            set
            {
                try
                {
                    tipo = value;

                    OnPropertyChanged();

                    ClearErrors("Tipo");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("Tipo", ex);
                }
            }
        }

        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set
            {
                try
                {
                    descricao = value;

                    OnPropertyChanged();

                    ClearErrors("Descricao");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("Descricao", ex);
                }
            }
        }

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
