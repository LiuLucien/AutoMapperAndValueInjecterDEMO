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
        IMapper GetMapper<T>()where T :new();
    }
}
