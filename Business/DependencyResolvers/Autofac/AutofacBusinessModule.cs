﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{

    // Dependency Injection (DI) için Autofac kullanarak iş katmanındaki bağımlılıkları kaydeden sınıf.

    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
           builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance(); 
           builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
           builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
           builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
           builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
           builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
           builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() 
                { 
                    Selector = new AspectInterceptorSelector() 
                }).SingleInstance();

        }
    }
}
