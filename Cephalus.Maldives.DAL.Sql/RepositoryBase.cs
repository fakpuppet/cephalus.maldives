using System;

namespace Cephalus.Maldives.DAL.Sql
{
    public abstract class RepositoryBase
    {
        protected string _connectionString;

        protected TResult ExecuteOnContext<TResult>(Func<MaldivesContext, TResult> function)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                return function(context);
            }
        }
    }
}
