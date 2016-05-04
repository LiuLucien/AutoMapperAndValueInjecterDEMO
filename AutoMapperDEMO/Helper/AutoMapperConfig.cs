using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapperDEMO.Models;
using AutoMapperDEMO.Helper;

namespace AutoMapperDEMO.Helper
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        public MapperConfiguration GetConfig<T>() where T : Profile, new()
        {
            return new MapperConfiguration(c => { c.AddProfile<T>(); });
        }

        public IMapper GetMapper<T>() where T : Profile, new()
        {
            return GetConfig<T>().CreateMapper();
        }

        public TDestination Map<TProfile, TDestination>(object source) where TProfile : Profile, new()
        {
            var mapper = GetMapper<TProfile>();

            return mapper.Map<TDestination>(source);
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
            CreateMap<Product, ProductViewModel>();

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