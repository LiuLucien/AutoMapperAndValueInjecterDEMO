using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.BeforeAndafterMapActionsDEMO
{
    class BeforeAndafterMapActions
    {
        public static void CustomtypeconvertersTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Dest>()
                  .BeforeMap((src, dest) => src.Value = src.Value + 10)
                  .AfterMap((src, dest) => dest.Name = "John");
            });
            var source = new Source
            {
                Name = "test",
                Value = 5
            };
            var mapper = config.CreateMapper();

            var Dest = mapper.Map<Source, Dest>(source);
        }
    }

    public class Source
    {
        public string Name { get; set; }

        public int Value { get; set; }
    }
    public class Dest
    {
        public string Name { get; set; }

        public int Value { get; set; }
    }
}
