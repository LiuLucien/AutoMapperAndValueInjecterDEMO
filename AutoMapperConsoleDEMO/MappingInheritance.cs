using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.MappingInheritanceDEMO
{
    class MappingInheritance
    {
        public static void MappingInheritanceTest()
        {
            //Mappings
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                      .Include<OnlineOrder, OrderDto>()
                      .Include<MailOrder, OrderDto>()
                      .ForMember(o => o.Referrer, m => m.Ignore());
                cfg.CreateMap<OnlineOrder, OrderDto>();
                cfg.CreateMap<MailOrder, OrderDto>();
            });

            // Perform Mapping
            var order = new OnlineOrder { Referrer = "google" };
            var mapper = config.CreateMapper();
            var mapped = mapper.Map(order, order.GetType(), typeof(OrderDto));
        }
    }

    //Domain Objects
    public class Order { }
    public class OnlineOrder : Order
    {
        public string Referrer { get; set; }
    }
    public class MailOrder : Order { }

    //Dtos
    public class OrderDto
    {
        public string Referrer { get; set; }
    }

}
