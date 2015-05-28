using System;
using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.Extensions
{
    public static class TestContextExtensions
    {
        public static T GetEnum<T>(this TestContext testContext, string columnName )
        {
            var columnValue = GetString(testContext, columnName);
            var enumValue = (T)Enum.Parse(typeof(T), columnValue);
            return enumValue;
        }
        
        public static T GetLookup<T>(this TestContext testContext, string columnName ) where T : Lookup
        {
            var columnValue = GetString(testContext, columnName);
            var lookup = Lookup.Find<T>(columnValue);
            return lookup;
        }

        public static IEnumerable<T> GetLookups<T>(this TestContext testContext, string columnName) where T : Lookup
        {
            var columnValue = GetString(testContext, columnName);
            var valueList = columnValue.Split(new[] { ',' });
            var lookups = valueList.Select ( s => (T) Lookup.Find<T>( s ) ).ToList ( );
            return lookups;
        }
        
        public static BloodPressure  GetBloodPressure ( this TestContext testContext, string columnName)
        {
            var columnValue = GetString(testContext, columnName);
            var valueList = columnValue.Split(new[] { ',' });
            return new BloodPressure ( uint.Parse ( valueList[0] ), uint.Parse ( valueList[1] ) );
        }
        
        public static int GetInt32(this TestContext testContext, string columnName)
        {
            var value = testContext.DataRow[columnName];
            var intValue = Convert.ToInt32(value);
            return intValue;
        }

        public static decimal GetDecimal(this TestContext testContext, string columnName)
        {
            var value = testContext.DataRow[columnName];
            var decimalValue = Convert.ToDecimal(value);
            return decimalValue;
        }

        public static double GetDouble(this TestContext testContext, string columnName)
        {
            var value = testContext.DataRow[columnName];
            var doubleValue = Convert.ToDouble(value);
            return doubleValue;
        }

        public static UInt32 GetUInt32(this TestContext testContext, string columnName)
        {
            var value = testContext.DataRow[columnName];
            var uintValue = Convert.ToUInt32(value);
            return uintValue;
        }

        public static Boolean GetBoolean(this TestContext testContext, string columnName)
        {
            var columnValue = GetString(testContext, columnName);
            var boolean = Boolean.Parse(columnValue);
            return boolean;
        }
        
        public static string GetString(this TestContext testContext, string columnName)
        {
            var columnValue = testContext.DataRow[columnName].ToString (  );
            return columnValue;
        }
    }
}
