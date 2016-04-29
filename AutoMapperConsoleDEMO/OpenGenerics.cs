using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.OpenGenericsDEMO
{
    class OpenGenerics
    {
        public static void OpenGenericsTest()
        {
            // Create the mapping
            var config = new MapperConfiguration(cfg => cfg.CreateMap(typeof(Source<>), typeof(Destination<>)));

            var source = new Source<int> { Value = 10 };

            var mapper = config.CreateMapper();

            var dest = mapper.Map<Source<int>, Destination<int>>(source);
        }
    }
    public class Source<T>
    {
        public T Value { get; set; }
    }

    public class Destination<T>
    {
        public T Value { get; set; }
    }
}
