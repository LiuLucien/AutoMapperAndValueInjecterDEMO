using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.ConditionalMappingDEMO
{
    class ConditionalMapping
    {
        public static void ConditionalMappingTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Foo, Bar>()
                  .ForMember(dest => dest.baz, opt => opt.Condition(src => (src.baz >= 0)));
            });
            var foo = new Foo()
            {
                baz = 5
            };

            var mapper = config.CreateMapper();

            var bar = mapper.Map<Bar>(foo);
        }
    }

    public class Foo
    {
        public int baz;
    }

    public class Bar
    {
        public uint baz;
    }
}
