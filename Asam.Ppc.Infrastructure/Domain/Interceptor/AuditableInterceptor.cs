using System;
using Asam.Ppc.Domain.CommonModule;
using NHibernate;
using NHibernate.Type;

namespace Asam.Ppc.Infrastructure.Domain.Interceptor
{
    [Serializable]
    public class AuditableInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            var entityModified = false;

            if (entity is IAuditable)
            {
                var dateTime = DateTimeOffset.Now;
                var systemAccountId = UserContext.SystemAccountKey.ToString();
                SetStateValue(propertyNames, state, "CreatedTimestamp", dateTime);
                SetStateValue(propertyNames, state, "UpdatedTimestamp", dateTime);
                SetStateValue(propertyNames, state, "CreatedSystemAccount", systemAccountId);
                SetStateValue(propertyNames, state, "UpdatedSystemAccount", systemAccountId);
                entityModified = true;
            }

            return entityModified;
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState,
                                          string[] propertyNames, IType[] types)
        {
            var entityModified = false;

            if (entity is IAuditable)
            {
                var dateTime = DateTimeOffset.Now;
                var systemAccountId = UserContext.SystemAccountKey.ToString();
                SetStateValue(propertyNames, currentState, "UpdatedTimestamp", dateTime);
                if ( systemAccountId != "-1" )
                {
                    SetStateValue ( propertyNames, currentState, "UpdatedSystemAccount", systemAccountId );
                }

                entityModified = true;
            }

            return entityModified;
        }


        private static void SetStateValue(string[] propertyNames, object[] state, string propertyName, object value)
        {
            int index = Array.IndexOf(propertyNames, propertyName);
            if (index == -1)
            {
                throw new AggregateException(string.Format("Property {0} not found.", propertyName));
            }

            state[index] = value;
        }
    }
}
