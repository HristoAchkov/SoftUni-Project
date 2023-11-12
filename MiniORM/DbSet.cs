using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity> 
        where TEntity : class, new()
    {
        // TODO: Create your DbSet class here.
        internal IList<TEntity> Entities { get; set; }
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        public DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        public int Count => Entities.Count;

        public bool IsReadOnly => Entities.IsReadOnly;

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }
            Entities.Add(item);
            ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = Entities.First();
                Remove(entity);
            }
        }

        public bool Contains(TEntity item)
        {
            return Entities.Contains(item);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            Entities.CopyTo(array, arrayIndex);
        }

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }
            var successfullyRemoved = Entities.Remove(item);

            if (successfullyRemoved)
            {
                ChangeTracker.Remove(item);
            }
            return successfullyRemoved;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}