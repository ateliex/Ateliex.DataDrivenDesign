using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public class EntityCollection<T> : ObservableCollection<T>
        where T : Entity
    {
        private readonly IList<T> deletedItems;

        public EntityCollection()
        {
            deletedItems = new List<T>();
        }

        public EntityCollection(IList<T> list)
            : base(list)
        {
            deletedItems = new List<T>();
        }

        protected override void InsertItem(int index, T item)
        {
            OnAddNew(item);

            base.InsertItem(index, item);
        }

        protected virtual void OnAddNew(T entity)
        {
            entity.State = EntityState.New;
        }

        public virtual Task SaveChanges()
        {
            deletedItems.Clear();

            return Task.CompletedTask;
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];

            OnRemoveItem(item);

            base.RemoveItem(index);
        }

        protected virtual void OnRemoveItem(T entity)
        {
            entity.State = EntityState.Deleted;

            deletedItems.Add(entity);
        }

        public IEnumerable<T> GetItemsBy(EntityState state)
        {
            IEnumerable<T> items;

            if (state == EntityState.Deleted)
            {
                items = this.deletedItems;
            }
            else
            {
                items = this.Where(p => p.State == state);
            }

            return items;
        }

        public delegate void StatusChangedHandler(string status);

        public event StatusChangedHandler StatusChanged;

        protected void SetStatus(string status)
        {
            if (StatusChanged != null)
            {
                StatusChanged(status);
            }

            //mainToolStripStatusLabel.Text = value;

            //statusBarTimer.Enabled = true;
        }
    }
}
