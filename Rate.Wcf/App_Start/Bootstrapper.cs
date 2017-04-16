using Autofac;
using Rate.Data.Core;
using Rate.Data.Core.Repository;
using Rate.Services.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rate.Wcf.App_Start
{
    public static class Bootstrapper
    {
        public static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EfContext>().As<IEfContext>();

            builder.RegisterGeneric(typeof(StandardRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterType<DefaultRateService>().As<IRateService>();

            return builder.Build();
        }
    }
}