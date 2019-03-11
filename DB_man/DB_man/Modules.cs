using System;
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
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace DB_man
{
    public class NewsModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestData>().To<GoogleNews>().WhenInjectedInto<MultiNewsProvider>().Intercept(context => true).With<ExceptionInterceptor>();
            Bind<IRequestData>().To<BBCNews>().WhenInjectedInto<MultiNewsProvider>().Intercept(context => true).With<ExceptionInterceptor>();
            Bind<IRequestData>().To<MockRequest>().WhenInjectedInto<SingleNewsProvider>();
            Bind<INewsProvider>().To<MultiNewsProvider>().Intercept(context => true).With<ExceptionInterceptor>(); 

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
            Bind<IDataAccess>().To<SqlDBAccess>().Named("Sql").Intercept(context => true).With<ExceptionInterceptor>(); ;
            Bind<IDataAccess>().To<CsvAccess>().Named("CSV").Intercept(context => true).With<ExceptionInterceptor>(); 

        }
    }

    public class AnalyticsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryFinder>().To<AzureCategoryFinder>().Intercept(context => true).With<ExceptionInterceptor>(); ;
        }
    }
}
