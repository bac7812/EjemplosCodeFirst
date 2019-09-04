using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class RepositorioGenerico<IEntity> where IEntity : class
    {
        protected ContextoTienda contexto;
        DbSet<IEntity> dbSet;

        public RepositorioGenerico(ContextoTienda contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<IEntity>();
        }

        public void añadir(IEntity entidad)
        {
            try
            {
                dbSet.Add(entidad);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
            }
        }

        public void modificar(IEntity entidad)
        {
            contexto.Entry(entidad).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void eliminar(IEntity entidad)
        {
            dbSet.Remove(entidad);
            contexto.Entry(entidad).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public void eliminar(Expression<Func<IEntity, bool>> predicado)
        {
            var entidades = dbSet.Where(predicado).ToList();
            entidades.ForEach(e => contexto.Entry(e).State = EntityState.Deleted);
            contexto.SaveChanges();
        }

        public List<IEntity> getGeneral()
        {
            return (List<IEntity>)contexto.Set<IEntity>().ToList();
        }

        public List<IEntity> get(Expression<Func<IEntity, bool>> filtrar = null, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<IEntity> queryable = dbSet;
            if (filtrar != null)
            {
                queryable = queryable.Where(filtrar);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                queryable = queryable.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(queryable).ToList();
            }
            else
            {
                return queryable.ToList();
            }
        }

        public IEntity singular(Expression<Func<IEntity, bool>> predicado)
        {
            return dbSet.FirstOrDefault(predicado);
        }
    }
}
