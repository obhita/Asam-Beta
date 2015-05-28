namespace Asam.Ppc.Service.Handlers.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Agatha.Common;
    using Infrastructure;
    using Messages.Common;
    using NHibernate;
    using NHibernate.Criterion;
    using Pillar.Domain;
    using global::AutoMapper;

    public abstract class PagedSearchRequestHandler<TEntity, TDto> : NHibernateSessionRequestHandler<PagedSearchRequest<TDto>, PagedSearchResponse<TDto>>
        where TEntity : Entity
    {
        public override Response Handle ( PagedSearchRequest<TDto> request )
        {
            var response = CreateTypedResponse ();

            var keyword = request.Keyword + "%";
            IQueryOver<TEntity> query = null;
            var entityQuery = Session.QueryOver<TEntity>()
                               .Where(WhereExpress(keyword));
            var organizationExpression = GetOrganization ();
            if ( organizationExpression != null )
            {
                query = entityQuery.JoinQueryOver ( organizationExpression )
                             .Where ( o => o.Key == UserContext.OrganizationKey );
            }
            else
            {
                query = entityQuery;
            }
            query = query.Skip ( request.Page * request.PageSize )
                         .Take ( request.PageSize );
            var result = query.Future<TEntity>() ?? Enumerable.Empty<TEntity> ();
            response.TotalCount = query.ToRowCountQuery().FutureValue<int>().Value;
            response.Results = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>> ( result.ToList() );
            return response;
        }

        protected abstract ICriterion WhereExpress ( string keyword );

        protected abstract Expression<Func<TEntity,Domain.OrganizationModule.Organization>> GetOrganization();
    }
}
