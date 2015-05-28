using System;
using System.Linq;
using System.Text;
using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.Common
{
    /// <summary>
    /// Tests to check the lookup integrity.
    /// </summary>
    [TestClass]
    public class LookupTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void NoDuplicateValuesAndNoEmptyName()
        {
            var lookupType = typeof ( Lookup );
            var assembly = lookupType.Assembly;
            var errorMsg = new StringBuilder ( );
            foreach (var type in assembly.GetTypes().Where(t => lookupType.IsAssignableFrom(t) && t != lookupType))
            {
                var lookups = Lookup.GetAll ( type.Name );
                if ( lookups.Any ( l => string.IsNullOrWhiteSpace ( l.Name ) ) )
                {
                    errorMsg.Append ( string.Format ( "Category '{0}' has empty name.{1}", type.Name, Environment.NewLine ) );
                }

                var duplicateGroup = lookups.GroupBy ( l => l.Value ).Where ( g => g.Count ( ) > 1 ).Select ( g => g.Key );
                if ( duplicateGroup.Count ( ) != 0 )
                {
                    errorMsg.Append ( string.Format ( "Category '{0}' has duplicate values. {1}", type.Name, Environment.NewLine ) );
                }
            }
            Assert.AreEqual ( string.Empty, errorMsg.ToString() );
        }

        [TestMethod]
        public void TestLookupOperators()
        {
            var x = LikertScale.Slightly;
            var y = LikertScale.Slightly;

            Assert.AreEqual ( true, x.Equals ( x ) );
            Assert.AreEqual ( true, x == x );

            Assert.AreEqual ( true, x.Equals ( LikertScale.Slightly ) );
            Assert.AreEqual ( true, x == LikertScale.Slightly );

            Assert.AreEqual ( true, x == y );
            Assert.AreEqual ( false, x > y );
            Assert.AreEqual ( false, x < y );
            Assert.AreEqual ( false, x != y );

            Assert.AreEqual ( false, x == LikertScale.Moderately );
            Assert.AreEqual ( false, x > LikertScale.Moderately );
            Assert.AreEqual ( true, x < LikertScale.Moderately );
            Assert.AreEqual ( true, x != LikertScale.Moderately );

            Assert.AreEqual ( true, x == 1 );
            Assert.AreEqual ( false, x > 1 );
            Assert.AreEqual ( false, x < 1 );
            Assert.AreEqual ( false, x != 1 );

            Assert.AreEqual ( false, x == 2 );
            Assert.AreEqual ( false, x > 2 );
            Assert.AreEqual ( true, x < 2 );
            Assert.AreEqual ( true, x != 2 );

            Assert.AreEqual ( x.Equals ( y ), y.Equals ( x ) );
            Assert.AreEqual ( x == y, y == x );
            Assert.AreEqual ( x.Equals ( LikertScale.Slightly ), LikertScale.Slightly.Equals ( x ) );
            Assert.AreEqual ( x == LikertScale.Slightly, LikertScale.Slightly == x );
            Assert.AreEqual ( x.Equals ( LikertScale.Moderately ), LikertScale.Moderately.Equals ( x ) );
            Assert.AreEqual ( x == LikertScale.Moderately, LikertScale.Moderately == x );


            Assert.AreEqual ( false, x.Equals ( null ) );
            LikertScale z = null;
            Assert.AreEqual ( true, z == null );
            Assert.AreEqual ( false, z != null );
            Assert.AreEqual ( x == z, z == x );
            z = LikertScale.NotAtAll;
            Assert.AreEqual ( false, z == null );
            Assert.AreEqual ( true, z != null );
            Assert.AreEqual ( x == z, z == x );
            //if (x.Equals(y) && y.Equals(z)) returns true, then x.Equals(z) returns true.
        }
    }
}
