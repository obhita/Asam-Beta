namespace Asam.Ppc.Service.Handlers.Assessment
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Domain.CommonModule;
    using NHibernate;
    using NHibernate.Properties;
    using NHibernate.Transform;

    public class ProjectedResultTransformer : IResultTransformer
    {
        private const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        private readonly System.Type resultClass;
        private ISetter[] setters;
        private readonly IPropertyAccessor propertyAccessor;
        private readonly ConstructorInfo constructor;

        public ProjectedResultTransformer(System.Type resultClass)
        {
            if (resultClass == null)
            {
                throw new ArgumentNullException("resultClass");
            }
            this.resultClass = resultClass;

            constructor = resultClass.GetConstructor(flags, null, System.Type.EmptyTypes, null);

            // if resultClass is a ValueType (struct), GetConstructor will return null... 
            // in that case, we'll use Activator.CreateInstance instead of the ConstructorInfo to create instances
            if (constructor == null && resultClass.IsClass)
            {
                throw new ArgumentException("The target class of a AliasToBeanResultTransformer need a parameter-less constructor",
                                            "resultClass");
            }

            propertyAccessor =
                new ChainedPropertyAccessor(new[]
                    {
                        PropertyAccessorFactory.GetPropertyAccessor(null),
                        PropertyAccessorFactory.GetPropertyAccessor("field")
                    });
        }

        public object TransformTuple(object[] tuple, String[] aliases)
        {
            if (aliases == null)
            {
                throw new ArgumentNullException("aliases");
            }
            object result;

            try
            {
                if (setters == null)
                {
                    setters = new ISetter[aliases.Length];
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        string alias = aliases[i];
                        if (alias != null)
                        {
                            var type = resultClass;
                            List<string> parts;
                            if ( (parts = alias.Split ( '.' ).ToList()).Count > 1 )
                            {
                                foreach ( var part in parts.Take ( parts.Count - 1 ) )
                                {
                                    type = propertyAccessor.GetGetter ( type, part ).ReturnType;
                                }
                            }
                            setters[i] = propertyAccessor.GetSetter(type, parts.Last());
                        }
                    }
                }
				
                // if resultClass is not a class but a value type, we need to use Activator.CreateInstance
                result = resultClass.IsClass
                             ? constructor.Invoke(null)
                             : NHibernate.Cfg.Environment.BytecodeProvider.ObjectsFactory.CreateInstance(resultClass, true);

                for (int i = 0; i < aliases.Length; i++)
                {
                    if (setters[i] != null)
                    {
                        var alias = aliases[i];
                        var type = resultClass;
                        var entityToSet = result;
                        List<string> parts;
                        if ((parts = alias.Split('.').ToList()).Count > 1)
                        {
                            foreach (var part in parts.Take(parts.Count - 1))
                            {
                                var getter = propertyAccessor.GetGetter ( type, part );
                                var subsetter = propertyAccessor.GetSetter ( type, part );
                                var origToSet = entityToSet;
                                type = getter.ReturnType;
                                entityToSet = getter.Get(entityToSet);
                                if ( entityToSet == null )
                                {
                                    entityToSet = Activator.CreateInstance ( type, true );
                                    subsetter.Set(origToSet, entityToSet);
                                }
                            }
                        }
                        var setter = setters[i];
                        var parameterType = setter.Method.GetParameters().Single().ParameterType;
                        Type genericType = null;
                        if (parameterType.IsGenericType && parameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                            && typeof(Lookup).IsAssignableFrom((genericType = parameterType.GetGenericArguments().Single())))
                        {
                            var listToSet = Activator.CreateInstance(typeof(List<>).MakeGenericType(genericType)) as IList;
                            if (tuple[i] != null)
                            {
                                listToSet.Add(Lookup.Find(genericType.Name, tuple[i].ToString()));
                            }
                            setters[i].Set(entityToSet, listToSet);
                        }
                        else
                        {
                            setters[i].Set ( entityToSet, tuple[i] );
                        }
                    }
                }
            }
            catch (InstantiationException e)
            {
                throw new HibernateException("Could not instantiate result class: " + resultClass.FullName, e);
            }
            catch (MethodAccessException e)
            {
                throw new HibernateException("Could not instantiate result class: " + resultClass.FullName, e);
            }

            return result;
        }

        public IList TransformList(IList collection)
        {
            //return collection;
            var groups = new Dictionary<long, Domain.AssessmentModule.Assessment> ();
            foreach ( Domain.AssessmentModule.Assessment assessment in collection )
            {
                if ( !groups.ContainsKey ( assessment.Key ) )
                {
                    groups.Add ( assessment.Key, assessment );
                }
                else
                {
                    AddIfNotEmptyAndIsNew ( ( groups[assessment.Key].CompletionSection.AcceptableLevelsOfCare as IList ), assessment.CompletionSection.AcceptableLevelsOfCare );
                }
            }
            return groups.Values.ToList ();
        }

        private static void AddIfNotEmptyAndIsNew<T> ( IList listToAddTo, IEnumerable<T> listToAddFrom )
        {
            if ( listToAddFrom.Count() != 0 )
            {
                var item = listToAddFrom.First ();
                if ( !listToAddTo.Contains ( item ) )
                {
                    listToAddTo.Add ( item );
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectedResultTransformer);
        }

        public bool Equals(ProjectedResultTransformer other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.resultClass, resultClass);
        }

        public override int GetHashCode()
        {
            return resultClass.GetHashCode();
        }
    }
}