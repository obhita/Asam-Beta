using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Domain.CommonModule
{
    /// <summary>
    ///     Provides a base implementation for lookups.
    /// </summary>
    [Component]
    public abstract class Lookup
    {
        //This is needed for nHibernate do not remove.
        private string _name;

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Lookup" /> class.
        /// </summary>
        protected internal Lookup()
        {
            IsDefault = false;
        }

        #endregion

        #region public Properties

        /// <summary>
        ///     Gets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [ColumnLength(200)]
        [NotNull]
        public virtual string Code { get; internal set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        [ColumnLength(200)]
        [NotNull]
        public virtual string Name
        {
            get
            {
                if (Code == null)
                {
                    return string.Empty;
                }
                string baseName = GetType().Namespace + "." + GetType().Name;
                var resourceManger = new ResourceManager(baseName, GetType().Assembly);
                return resourceManger.GetString(Code) ?? string.Empty;
            }
        }


        /// <summary>
        ///     Gets the value.
        /// </summary>
        public virtual int Value { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether is default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if is default; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsDefault { get; internal set; }

        /// <summary>
        ///     Gets the sort order number.
        /// </summary>
        /// <value>
        ///     The sort order number.
        /// </value>
        public virtual int? SortOrder { get; internal set; }

        #endregion

        #region public virtual Methods

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <typeparam name="T">The Lookup.</typeparam>
        /// <returns>IEnumerable of Lookup.</returns>
        public static IEnumerable<T> GetAll<T>() where T : Lookup
        {
            Type type = typeof (T);
            IEnumerable<FieldInfo> fields =
                type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(f => f.FieldType == typeof (T));

            IEnumerable<T> lookups = from f in fields
                                     let looupItem = (T) f.GetValue(null)
                                     orderby looupItem.SortOrder
                                     select looupItem;

            return lookups;
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        /// <returns>IEnumerable of Lookup.</returns>
        public static IEnumerable<Lookup> GetAll(string lookupType)
        {
            Type[] types = typeof (Lookup).Assembly.GetTypes();

            Type type = types.FirstOrDefault(t => t.Name == lookupType && typeof (Lookup).IsAssignableFrom(t));

            if (type == null)
            {
                throw new ApplicationException(string.Format("Cannot find lookup type '{0}'", lookupType));
            }

            IEnumerable<FieldInfo> fields =
                type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(
                    f => typeof (Lookup).IsAssignableFrom(f.FieldType));

            IEnumerable<Lookup> lookupItems = from f in fields
                                              let looupItem = (Lookup) f.GetValue(null)
                                              orderby looupItem.SortOrder
                                              select looupItem;

            return lookupItems;
        }

        /// <summary>
        ///     Finds the specified code.
        /// </summary>
        /// <typeparam name="T">The Lookup.</typeparam>
        /// <param name="code">The code.</param>
        /// <returns>A lookup.</returns>
        public static T Find<T>(string code) where T : Lookup
        {
            T lookup = GetAll<T>().FirstOrDefault(l => l.Code == code);

            return lookup;
        }

        /// <summary>
        ///     Finds the specified lookup type.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        /// <param name="code">The code.</param>
        /// <returns>A lookup.</returns>
        public static Lookup Find(string lookupType, string code)
        {
            Lookup lookup = GetAll(lookupType).FirstOrDefault(l => l.Code == code);

            return lookup;
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Lookup" /> to <see cref="System.Int32" />.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator int(Lookup lookup)
        {
            //TODO: Verify return -1 when null is ok?
            return lookup == null ? -1 : lookup.Value;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        #region ==

        public static bool operator ==(Lookup left, Lookup right)
        {
            //http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object) left == null) || ((object) right == null))
            {
                return false;
            }

            // Return true if the fields match:
            return left.Value == right.Value;
        }

        #endregion

        #region !=

        public static bool operator !=(Lookup left, Lookup right)
        {
            return !(left == right);
        }

        #endregion

        #endregion

        #region Equalty members

        public virtual bool Equals(Lookup other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Code, Code);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
        /// </returns>
        /// <param name="obj">
        ///     The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.
        /// </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as Lookup);
        }

        /// <summary>
        ///     Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Code != null ? Code.GetHashCode() : 0);;
                return result;
            }
        }

        #endregion
    }
}