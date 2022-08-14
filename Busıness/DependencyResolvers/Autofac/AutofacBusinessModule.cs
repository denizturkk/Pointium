using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    //Module : Autofacten gelir 
    //Burada IOC container register islemleri yapilacak
    public class AutofacBusinessModule:Module
    {
        protected override void Load (ContainerBuilder builder)
        {
           builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
           builder.RegisterType<EfProjectDal>().As<IProjectDal>().SingleInstance();

           builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
           builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<UserDetailManager>().As<IUserDetailService>().SingleInstance();
            builder.RegisterType<EfUserDetailDal>().As<IUserDetailDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<UserProjectManager>().As<IUserProjectService>().SingleInstance();
            builder.RegisterType<EfUserProjectDal>().As<IUserProjectDal>();

            builder.RegisterType<UserProjectDayManager>().As<IUserProjectDayService>().SingleInstance();
            builder.RegisterType<EfUserProjectDayDal>().As<IUserProjectDayDal>();






            //for Enabling aspect Autofac extras dynamicproxy
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
    }
}
