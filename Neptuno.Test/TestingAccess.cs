using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptuno.Data;
using Neptuno.Data.Repositories;
using Neptuno.Domain.Entities;

namespace Neptuno.Test
{
    [TestClass]
    public class TestingAccess
    {
        [TestMethod]
        public void GetProductos()
        {
            var context = new NeptunoContext();

            var repo = new RepositoryGeneric<Producto>(context);

            Func<IQueryable<Producto>, IOrderedQueryable<Producto>> orderby = Ordenar();


            repo.GetMany(x => x.Activo, orderby);

        }



        private Func<IQueryable<Producto>, IOrderedQueryable<Producto>> Ordenar()
        {
            var items = Enumerable.Empty<Producto>().AsQueryable();



            return x => x.AppendOrderBy(y => y.IdCategoria, ListSortDirection.Ascending, false).AppendOrderBy(y => y.PrecioUnidad, ListSortDirection.Descending, true).AppendOrderBy(y => y.Suspendido, ListSortDirection.Ascending, true);
        }


        
    }
    static class QueryableExtensions
    {
        public static IOrderedQueryable<T> AppendOrderBy<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> sortSelector, ListSortDirection orderby, bool concatena)
        {
            var ordered = source as IOrderedQueryable<T>;
            if (ordered != null)
            {
                var lastMethod = (source.Expression as MethodCallExpression)?.Method;

                if (lastMethod?.DeclaringType == typeof(Queryable))
                    switch (lastMethod.Name)
                    {
                        case nameof(Queryable.OrderBy):
                        case nameof(Queryable.OrderByDescending):
                        case nameof(Queryable.ThenBy):
                        case nameof(Queryable.ThenByDescending):
                            return concatena ? orderby == ListSortDirection.Ascending ? ordered.ThenBy(sortSelector) : ordered.ThenByDescending(sortSelector) : ordered;
                    }
            }

            return concatena ?  orderby == ListSortDirection.Ascending ? source.OrderBy(sortSelector) : source.OrderByDescending(sortSelector) : ordered;
        }

    }
}

