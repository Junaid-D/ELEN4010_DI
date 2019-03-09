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
using Ninject;
using Ninject.Modules;

namespace DB_man
{
    public class NewsModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestData>().To<GoogleNews>().WhenInjectedInto<MultiNewsProvider>();
            Bind<IRequestData>().To<BBCNews>().WhenInjectedInto<MultiNewsProvider>();//conditional based on the class being injected into
            Bind<IRequestData>().To<MockRequest>().WhenInjectedInto<SingleNewsProvider>();
            Bind<INewsProvider>().To<SingleNewsProvider>();

        }
    }

    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<MultiStoreSaver>();
            Bind<IDataAccess>().To<CsvAccess>().WhenInjectedInto<MultiStoreSaver>();
            Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<SingleStoreSaver>();
            Bind<IResponseSaver>().To<SingleStoreSaver>();
            Bind<IDataAccess>().To<SqlDBAccess>().Named("Sql");// bind with argument to instantiate concrete
            Bind<IDataAccess>().To<CsvAccess>().Named("CSV");

        }
    }

    public class AnalyticsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryFinder>().To<AzureCategoryFinder>();
        }
    }
}