using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperDEMO.Models;
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
                                            cfg.CreateMap<ProductCategory, CategoryViewModel>()
                                            .ForMember(dto => dto.productNames,
                                                              conf => conf.MapFrom(ol => ol.Product.Select(s => s.Name))
                                                       ));

        public static void QueryableExtensionsTest()
        {
            using (var context = new AutoMapperAndValueInjecterDEMOEntities())
            {
                var category = context.ProductCategory.Include(nameof(context.Product)).FirstOrDefault();

                if (category != null)
                {
                    // Perform mapping
                    var mapper = Config.CreateMapper();
                    var result = mapper.Map<ProductCategory, CategoryViewModel>(category);

                    var vm = GetProductNamesByCategoryId(category.Id);
                }
            }
        }

        public static CategoryViewModel GetProductNamesByCategoryId(int CategoryId)
        {
            using (var context = new AutoMapperAndValueInjecterDEMOEntities())
            {
                return context.ProductCategory.Where(ol => ol.Id == CategoryId)
                         .ProjectTo<CategoryViewModel>(Config).FirstOrDefault();
            }
        }
    }
}
