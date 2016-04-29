using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.NullsubstitutionDEMO
{
    class Nullsubstitution
    {
        public static void NullsubstitutionTest()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Dest>()
    .ForMember(x => x.Value, opt => opt.NullSubstitute("Other Value")));

            var source = new Source { Value = null };
            var mapper = config.CreateMapper();
            var dest = mapper.Map<Source, Dest>(source);

            source.Value = "Not null";

            dest = mapper.Map<Source, Dest>(source);
        }
    }


    public class Source
    {
        public string Value { get; set; }
    }
    public class Dest
    {
        public string Value { get; set; }
    }
}
