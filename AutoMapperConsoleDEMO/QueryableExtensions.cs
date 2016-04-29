using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.QueryableExtensionsDEMO
{
    class QueryableExtensions
    {
        static MapperConfiguration Config = new MapperConfiguration(cfg =>
        cfg.CreateMap<OrderLine, OrderLineDTO>()
        .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name)));

        //需連接DB
        //public List<OrderLineDTO> GetLinesForOrder(int orderId)
        //{
        //    using (var context = new orderEntities())
        //    {
        //        return context.OrderLines.Where(ol => ol.OrderId == orderId)
        //                 .ProjectTo<OrderLineDTO>(Config).ToList();
        //    }
        //}
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderLineDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Item { get; set; }
        public decimal Quantity { get; set; }
    }
}
