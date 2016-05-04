using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDEMO.Helper
{
    public interface IAutoMapperConfig
    {
        /// <summary>
        /// 取的設定
        /// </summary>
        /// <typeparam name="T">Mapper需要的Profile</typeparam>
        /// <returns></returns>
        MapperConfiguration GetConfig<T>() where T : Profile, new();

        /// <summary>
        /// 建立對映
        /// </summary>
        /// <typeparam name="T">Mapper需要的Profile</typeparam>
        /// <returns></returns>
        IMapper GetMapper<T>() where T : Profile, new();

        /// <summary>
        /// 傳入Mapper需要的Profile之後直接進行對映
        /// </summary>
        /// <typeparam name="TProfile"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination Map<TProfile, TDestination>(object source) where TProfile : Profile, new();
    }
}