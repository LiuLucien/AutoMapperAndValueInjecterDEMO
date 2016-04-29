using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.CustomtypeconvertersDEMO
{
    class Customtypeconverters
    {
        public static void CustomtypeconvertersTest()
        {
            var config = new MapperConfiguration(cfg => {
                //有問題
                //cfg.CreateMap<string, int>().ConvertUsing(Convert.ToInt32);
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();
                cfg.CreateMap<Source, Destination>();
            });
            config.AssertConfigurationIsValid();

            var source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "AutoMapperSamples.GlobalTypeConverters.GlobalTypeConverters+Destination"
            };

            var mapper = config.CreateMapper();
            Destination result = mapper.Map<Source, Destination>(source);
        }

        public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(ResolutionContext context)
            {
                return System.Convert.ToDateTime(context.SourceValue);
            }
        }

        public class TypeTypeConverter : ITypeConverter<string, Type>
        {
            public Type Convert(ResolutionContext context)
            {
                return context.SourceType;
            }
        }

        public class Source
        {
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }
        }
        public class Destination
        {
            public int Value1 { get; set; }
            public DateTime Value2 { get; set; }
            public Type Value3 { get; set; }
        }
    }
}
