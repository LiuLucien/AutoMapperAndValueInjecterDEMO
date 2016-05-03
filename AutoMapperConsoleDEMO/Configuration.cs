using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.ConfigurationDEMO
{
    class Configuration
    {
        public static void ConfigurationTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ReplaceMemberName("Ä", "A");
                cfg.ReplaceMemberName("í", "i");
                cfg.ReplaceMemberName("Airlina", "Airline");
                cfg.CreateMap<Source, Destination>();
            });

            var source = new Source
            {
                Value = 1,
                Ävíator = 2,
                SubAirlinaFlight = 3
            };
            var mapper = config.CreateMapper();
            var result = mapper.Map<Source, Destination>(source);
        }
    }

    public class Source
    {
        public int Value { get; set; }
        public int Ävíator { get; set; }
        public int SubAirlinaFlight { get; set; }
    }
    public class Destination
    {
        public int Value { get; set; }
        public int Aviator { get; set; }
        public int SubAirlineFlight { get; set; }
    }
}
