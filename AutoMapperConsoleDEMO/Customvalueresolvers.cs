using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.CustomvalueresolversDEMO
{
    class Customvalueresolvers
    {
        public static void CustomvalueresolversTest()
        {
            var config = new MapperConfiguration(cfg => 
                        cfg.CreateMap<Source, Destination>()
                        .ForMember(dest => dest.Total, opt => opt.ResolveUsing<CustomResolver>()));
            config.AssertConfigurationIsValid();

            var source = new Source
            {
                Value1 = 5,
                Value2 = 7
            };
            var mapper = config.CreateMapper();
            var result = mapper.Map<Source, Destination>(source);
        }
    }
    public interface IValueResolver
    {
        ResolutionResult Resolve(ResolutionResult source);
    }
    public class CustomResolver : ValueResolver<Source, int>
    {
        protected override int ResolveCore(Source source)
        {
            return source.Value1 + source.Value2;
        }
    }

    public class Source
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class Destination
    {
        public int Total { get; set; }
    }
}
