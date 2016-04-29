using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.ConfigurationValidationDEMO
{
    class ConfigurationValidation
    {
        public static void ConfigurationValidationTest()
        {
            var config = new MapperConfiguration(cfg =>
      cfg.CreateMap<Source, Destination>());

            config.AssertConfigurationIsValid();
        }
    }

    public class Source
    {
        public int SomeValue { get; set; }
    }

    public class Destination
    {
        public int SomeValuefff { get; set; }
    }
}
