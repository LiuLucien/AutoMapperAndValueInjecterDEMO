using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapperDEMO.Models;
using AutoMapperDEMO.Helper;

namespace AutoMapperDEMO
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        //public IMapper GetMapper(Profile profile)
        //{
        //    var config = new MapperConfiguration(c => { c.AddProfile(profile); });
        //    return config.CreateMapper();
        //}

        public IMapper GetMapper<T>() where T : new()
        {
            //T t = new T();
            //var name = nameof(T);
            //var config = new MapperConfiguration(c => { c.AddProfile(new Profile(name)()); });
            //return config.CreateMapper();
            throw new NotImplementedException();
        }
    }

    public class ProductIndexProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }

    public class ProductDetailsProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductDetailViewModel>().ForMember(s => s.CategoryName, a => a.MapFrom(x => x.ProductCategory.Name));
            CreateMap<ProductViewModel, Product>()
                                                .ForMember(s => s.Id, a => a.Ignore())
                                                .ForMember(s => s.Name, a => a.MapFrom(s => string.Format("{0}{1}", s.SerialNo, s.Name)))
                                                .ForMember(s => s.Description, a => a.MapFrom(s => s.Desc))
                                                .ForMember(s => s.CreatedOnUtc, a => a.UseValue(DateTime.UtcNow));
        }
    }

    public class ProductCreateProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProductViewModel, Product>()
                                                .ForMember(s => s.Id, a => a.Ignore())
                                                .ForMember(s => s.Name, a => a.MapFrom(s => string.Format("{0}{1}", s.SerialNo, s.Name)))
                                                .ForMember(s => s.Description, a => a.MapFrom(s => s.Desc))
                                                .ForMember(s => s.CreatedOnUtc, a => a.UseValue(DateTime.UtcNow));
            CreateMap<ProductDemoModel, Product>();
        }
    }

    public class ProductEditProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProductViewModel, Product>()
                                               //設定Product的Id不對映
                                               .ForMember(s => s.Id, a => a.Ignore())
                                               //設定Product的Name對映到ProductViewModel的SerialNo加Name
                                               .ForMember(s => s.Name, a => a.MapFrom(x => string.Format("{0}{1}",
                                                                                                        x.SerialNo,
                                                                                                        x.Name)))
                                               //設定Product的Description對映到ProductViewModel的Desc
                                               .ForMember(s => s.Description, a => a.MapFrom(x => x.Desc))
                                               //設定Product的ModifiedOnUtc預設為DateTime.UtcNow
                                               .ForMember(s => s.ModifiedOnUtc, a => a.UseValue(DateTime.UtcNow));
        }
    }

    public class ProductCategoryProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProductCategory, CategoryViewModel>();
            CreateMap<List<string>, CategoryViewModel>().ForMember(category => category.productNames, product => product.MapFrom(s => s));
        }
    }
}