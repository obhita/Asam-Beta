using System;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    /// <summary>
    /// Class RouteInfo
    /// </summary>
    public class RouteInfo : IEquatable<RouteInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteInfo" /> class.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="subSection">The sub section.</param>
        /// <param name="orderIndex">Index of the order.</param>
        public RouteInfo ( string section, string subSection, int orderIndex = 0 )
        {
            Section = section;
            SubSection = subSection;
            OrderIndex = orderIndex;
            HasSubsection = subSection != null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteInfo" /> class.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="orderIndex">Index of the order.</param>
        public RouteInfo ( string section, int orderIndex = 0 )
        {
            Section = section;
            OrderIndex = orderIndex;
            HasSubsection = false;
        }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <value>The section.</value>
        public string Section { get; private set; }
        /// <summary>
        /// Gets the sub section.
        /// </summary>
        /// <value>The sub section.</value>
        public string SubSection { get; private set; }
        /// <summary>
        /// Gets the index of the order.
        /// </summary>
        /// <value>The index of the order.</value>
        public int OrderIndex { get; set; }
        /// <summary>
        /// Gets a value indicating whether this instance has subsection.
        /// </summary>
        /// <value><c>true</c> if this instance has subsection; otherwise, <c>false</c>.</value>
        public bool HasSubsection { get; private set; }

        #region IEquatable<RouteInfo> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals ( RouteInfo other )
        {
            if ( ReferenceEquals ( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals ( this, other ) )
            {
                return true;
            }
            return string.Equals ( Section, other.Section ) && string.Equals ( SubSection, other.SubSection );
        }

        #endregion

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        public override bool Equals ( object obj )
        {
            if ( ReferenceEquals ( null, obj ) )
            {
                return false;
            }
            if ( ReferenceEquals ( this, obj ) )
            {
                return true;
            }
            if ( obj.GetType () != GetType () )
            {
                return false;
            }
            return Equals ( (RouteInfo) obj );
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode ()
        {
            unchecked
            {
                int hashCode = ( Section != null ? Section.GetHashCode () : 0 );
                hashCode = ( hashCode * 397 ) ^ ( SubSection != null ? SubSection.GetHashCode () : 0 );
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator == ( RouteInfo left, RouteInfo right )
        {
            return Equals ( left, right );
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator != ( RouteInfo left, RouteInfo right )
        {
            return !Equals ( left, right );
        }

        /// <summary>
        /// Parses the specified route string.
        /// </summary>
        /// <param name="routeString">The route string.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static RouteInfo Parse ( string routeString )
        {
            var parts = routeString.Split ( new[] {"/"}, StringSplitOptions.RemoveEmptyEntries );
            if ( parts.Length == 2 )
            {
                return new RouteInfo ( parts[0], parts[1] );
            }
            if ( parts.Length == 1 )
            {
                return new RouteInfo ( parts[0] );
            }
            throw new ArgumentException ( "Not a valid route string", routeString );
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return HasSubsection
                       ? string.Format ( "{0}/{1}", Section, SubSection )
                       : string.Format("{0}", Section);
        }
    }
}