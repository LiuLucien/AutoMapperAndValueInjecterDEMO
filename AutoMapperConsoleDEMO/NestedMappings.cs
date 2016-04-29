using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.NestedMappingsDEMO
{
    class NestedMappings
    {
        public static void NestedMappingsTest()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OuterSource, OuterDest>();
                cfg.CreateMap<InnerSource, InnerDest>();
            });
            config.AssertConfigurationIsValid();

            var source = new OuterSource
            {
                Value = 5,
                Inner = new InnerSource { OtherValue = 15 }
            };
            var mapper = config.CreateMapper();
            var dest = mapper.Map<OuterSource, OuterDest>(source);
        }
    }

    public class OuterSource
    {
        public int Value { get; set; }
        public InnerSource Inner { get; set; }
    }

    public class InnerSource
    {
        public int OtherValue { get; set; }
    }

    public class OuterDest
    {
        public int Value { get; set; }
        public InnerDest Inner { get; set; }
    }

    public class InnerDest
    {
        public int OtherValue { get; set; }
    }
}
