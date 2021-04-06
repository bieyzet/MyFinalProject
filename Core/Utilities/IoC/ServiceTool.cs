using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //(istedigimz servicin karsılıgını bize bulur.)
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
//dependencyleri yakalamak için kullanıyoruz.
 //yani injektion altyapımızı aynen okumak için kullanıyoruz.
 
