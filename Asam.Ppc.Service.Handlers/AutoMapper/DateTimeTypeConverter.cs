using System;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.AutoMapper
{
    public class DateTimeTypeConverter : TypeConverter<DateTimeOffset, DateTime>
    {
        protected override DateTime ConvertCore(DateTimeOffset source)
        {
            return source.DateTime;
        }
    }
}