using System;
using System.ComponentModel;
using CrossCutting.Settings;
using Domain.Business;
using Domain.Business.Contracts;
using Domain.Contexts.Contracts;
using Domain.Models;
using Domain.Repositories;
using Domain.Validators;
using FluentValidation;
using Mariadb.Contexts;
using Mariadb.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace IOC
{
    public class Container
    {
         #region Properties
        
        private static SimpleInjector.Container _container;
        private static bool _verified = false;
        
        #endregion
        
        
        #region INIT

        public static void Init()
        {
            _container = new SimpleInjector.Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Options.DefaultLifestyle = new AsyncScopedLifestyle();
        }

        public static void InitRegisters(AppSettings appSettings)
        {
            
            
            RegisterValidator();
            RegisterData(appSettings);
            RegisterBusiness();
            RegisterRepository();
        }

        public static void InitServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services.AddSimpleInjector(_container,
                options => options
                    .AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation()
            );

            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        public static void InitConsoleServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void InitApplication(IApplicationBuilder app)
        {
            app.UseSimpleInjector(_container);
            Verify();
        }

        public static SimpleInjector.Container GetRegister()
        {
            return _container;
        }

        public static void Verify()
        {
            if (_verified) return;

            _container.Verify();
            _verified = true;
        }

        #endregion


        #region DEPENDENCIES

        private static void RegisterValidator()
        {
            _container.Register<AbstractValidator<Person>, PersonValidator>(Lifestyle.Scoped);
        }

        private static void RegisterData(AppSettings appSettings)
        {
            var connectionString = appSettings.ConnectionStrings.WebpicConnection;
            
            _container.Register<IWebpicContext>(() => 
                new WebpicContext(new DbContextOptionsBuilder<WebpicContext>()
                .UseMySql(appSettings.ConnectionStrings.WebpicConnection, 
                    ServerVersion.AutoDetect(connectionString)).Options), Lifestyle.Scoped);
        }

        private static void RegisterBusiness()
        {
            _container.Register<IPersonBusiness, PersonBusiness>(Lifestyle.Scoped);
        }

        private static void RegisterRepository()
        {
            _container.Register<IPersonRepository, PersonRepository>(Lifestyle.Scoped);
        }
        
        #endregion
        
        
        #region MEMBERS

        public static IContainer GetIContainer() => _container.GetInstance<IContainer>();

        public static SimpleInjector.Container GetContainer() => _container;


        #endregion
    }
}