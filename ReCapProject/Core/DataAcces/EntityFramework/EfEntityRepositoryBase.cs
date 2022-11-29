using Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    // standart hale getiriyoruz. bana bir entity birde context ver ben bu işlemleri yapıcam.

      public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
      {

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) // c# a özel yapı. Idisposable pattern implementation of c# -using
            {
                var addedEntity = context.Entry(entity); // veri kaynağına gönderdiğim producta bir tane nesneyi eşleştir. vt ilişkilendirir. Referans yakaladı
                addedEntity.State = EntityState.Added; // peki şimdi bunu ne yapayım ? -ekle / o aslında eklenecek bir nesne
                context.SaveChanges(); // ekledim.

            }
        }




        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // c# a özel yapı. Idisposable pattern implementation of c#
            {
                var deletedEntity = context.Entry(entity); // veri kaynağından gönderdiğim producta bir tane nesneyi eşleştir. vt ilişkilendirir. Referans yakaladı
                deletedEntity.State = EntityState.Deleted; // peki şimdi bunu ne yapayım ? -sil / o aslında silinecek bir nesne
                context.SaveChanges(); // sildim..

            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter) // tek data getirecek.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // " : "  yere kadar filter null mu ? eğer null sa listele.  : den sonra şartı yerine getir.

                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }




        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // c# a özel yapı. Idisposable pattern implementation of c#
            {
                var updatedEntity = context.Entry(entity); // veri kaynağından gönderdiğim producta bir tane nesneyi eşleştir. vt ilişkilendirir. Referans yakaladı
                updatedEntity.State = EntityState.Modified; // peki şimdi bunu ne yapayım ? -güncelle / o aslında güncellenecek bir nesne
                context.SaveChanges(); // güncelledim...

            }
        }
    }
}


