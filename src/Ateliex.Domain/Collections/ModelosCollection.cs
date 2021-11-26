using Ateliex.Models;
using Ateliex.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Ateliex.Collections
{
    public class ModelosCollection : EntityCollection<Modelo>
    {
        private readonly IModelosService modelosService;

        public ModelosCollection(IModelosService modelosService)
        {
            this.modelosService = modelosService;
        }

        public async Task Load()
        {
            var modelos = await modelosService.ObtemModelosAsync();

            foreach (var modelo in modelos)
            {
                Items.Add(modelo);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void OnAddNew(Modelo entity)
        {
            base.OnAddNew(entity);

            //await modelosService.AddAsync(entity);

            //SetStatus($"Novo modelo '{entity.Codigo}' cadastrado com sucesso.");
        }

        public async override Task SaveChanges()
        {
            var newItems = GetItemsBy(EntityState.New);

            foreach (var newItem in newItems)
            {
                try
                {
                    await modelosService.AddAsync(newItem);

                    SetStatus($"Novo modelo '{newItem.Codigo}' cadastrado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var modifiedItems = GetItemsBy(EntityState.Modified);

            foreach (var modifiedItem in modifiedItems)
            {
                try
                {
                    await modelosService.UpdateAsync(modifiedItem);

                    SetStatus($"Modelo '{modifiedItem.Codigo}' atualizado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var deletedItems = GetItemsBy(EntityState.Deleted);

            foreach (var deletedItem in deletedItems)
            {
                try
                {
                    await modelosService.RemoveAsync(deletedItem);

                    SetStatus($"Modelo '{deletedItem.Codigo}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            await base.SaveChanges();
        }
    }

    public class RecursosCollection : EntityCollection<Recurso>
    {
        protected internal Modelo modelo;

        public RecursosCollection(IList<Recurso> list)
            : base(list)
        {
            //foreach (var item in list)
            //{
            //    item.collection = this;
            //}
        }

        protected override void OnAddNew(Recurso entity)
        {
            base.OnAddNew(entity);

            entity.Modelo = modelo;

            //await modelosService.AddAsync(entity);

            //SetStatus($"Novo modelo '{entity.Codigo}' cadastrado com sucesso.");
        }
    }
}
