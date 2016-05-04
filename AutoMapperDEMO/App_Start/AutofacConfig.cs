using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Mappers;
using AutoMapper;
using AutoMapperDEMO.Helper;

namespace AutoMapperDEMO.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //容器建立者
            var builder = new ContainerBuilder();
            //註冊Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //註冊組件型別,透過Namespace 來取得所有介面與介面實作
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(i => i.Namespace.EndsWith(".Helper"))
                   .AsImplementedInterfaces();

            //建立容器
            var container = builder.Build();

            //指定解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}