using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Task1.Convertor
{
    public class DateOnlyConverter: ValueConverter<DateOnly, DateTime>
    {

        public DateOnlyConverter()
       : base(
           dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
           dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }

}
