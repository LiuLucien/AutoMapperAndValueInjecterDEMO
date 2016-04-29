using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.ListsAndArraysDEMO
{
    class ListsAndArrays
    {
        public static void ListsAndArraysTest()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            var sources = new[]
                {
                    new Source { Value = 5 },
                    new Source { Value = 6 },
                    new Source { Value = 7 }
                };

            var mapper = config.CreateMapper();
            IEnumerable<Destination> ienumerableDest = mapper.Map<Source[], IEnumerable<Destination>>(sources);
            ICollection<Destination> icollectionDest = mapper.Map<Source[], ICollection<Destination>>(sources);
            IList<Destination> ilistDest = mapper.Map<Source[], IList<Destination>>(sources);
            List<Destination> listDest = mapper.Map<Source[], List<Destination>>(sources);
            Destination[] arrayDest = mapper.Map<Source[], Destination[]>(sources);
        }

        public static void ListsAndArrayselementtypesTest()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ParentSource, ParentDestination>()
                     .Include<ChildSource, ChildDestination>();
                c.CreateMap<ChildSource, ChildDestination>();
            });
            var sources = new[]
                {
                    new ParentSource(),
                    new ChildSource(),
                    new ParentSource()
                };

            var mapper = config.CreateMapper();
            var destinations = mapper.Map<ParentSource[], ParentDestination[]>(sources);
        }
    }

    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }
    }

    public class ParentSource
    {
        public int Value1 { get; set; }
    }

    public class ChildSource : ParentSource
    {
        public int Value2 { get; set; }
    }

    public class ParentDestination
    {
        public int Value1 { get; set; }
    }

    public class ChildDestination : ParentDestination
    {
        public int Value2 { get; set; }
    }
}
