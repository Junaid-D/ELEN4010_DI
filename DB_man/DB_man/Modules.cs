﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using DB_man.Classification;
using DB_man.DataAccess;
using DB_man.RequestClasses;
using DB_man.RequestInterfaces;
using DB_man.ResponseIntefaces;
using Microsoft.Win32;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace DB_man
{
    /// <summary>
    /// Ninject module for type registrations related to news request classes
    /// </summary>

    public class NewsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestData>().To<GoogleNews>().WhenInjectedInto<MultiNewsProvider>().Intercept(context => true).With<ExceptionInterceptor>();
            Bind<IRequestData>().To<BBCNews>().WhenInjectedInto<MultiNewsProvider>().Intercept(context => true).With<ExceptionInterceptor>();
            Bind<IRequestData>().To<MockRequest>().WhenInjectedInto<SingleNewsProvider>();
            Bind<INewsProvider>().To<MultiNewsProvider>().Named("MultiNews").Intercept(context => true).With<ExceptionInterceptor>();

        }
    }

    /// <summary>
    /// Ninject module for type registrations related to DAL classes
    /// </summary>

    public class DataAccessModule : NinjectModule
    {
        //registry key that is present when access runtime is installed
        private string dbCheckString = "Microsoft.ACE.OLEDB.12.0";


        public override void Load()
        {

            Bind<IDataAccess>().To<CsvAccess>().WhenInjectedInto<MultiStoreSaver>().Intercept(context => true).With<ExceptionInterceptor>();

            Bind<IResponseSaver>().To<MultiStoreSaver>().Named("Multi");
            Bind<IDataRetriever>().To<SimpleDataRetriever>();

            RegistryKey accessRegKey = Registry.ClassesRoot.OpenSubKey(dbCheckString, false);
            //conditional check if access runtime is installed (USE CSV by default).
            if (accessRegKey != null)//if access support is available.
            {
                Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<MultiStoreSaver>().Intercept(context => true).With<ExceptionInterceptor>();
                Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<SingleStoreSaver>().Intercept(context => true).With<ExceptionInterceptor>();
                
                Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<SimpleDataRetriever>().Intercept(context => true).With<ExceptionInterceptor>();
            }
            else
            {
                Bind<IDataAccess>().To<CsvAccess>().WhenInjectedInto<SingleStoreSaver>().Intercept(context => true).With<ExceptionInterceptor>();
                Bind<IDataAccess>().To<CsvAccess>().WhenInjectedInto<SimpleDataRetriever>().Intercept(context => true).With<ExceptionInterceptor>();
            }

        }
    }

    /// <summary>
    /// Ninject module for type registrations related to analytics classes
    /// </summary>

    public class AnalyticsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryFinder>().To<AzureCategoryFinder>().Intercept(context => true).With<ExceptionInterceptor>(); ;
        }
    }
}
