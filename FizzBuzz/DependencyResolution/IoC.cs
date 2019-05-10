using FizzBuzz.Service;
using FizzBuzz.Service.Interface;
using StructureMap;
using System.Configuration;
namespace FizzBuzz {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<ICheckDay>().Use<CheckDay>().Ctor<string>().Is(ConfigurationManager.AppSettings["DayOfWeek"].ToString());
                            x.For<IRule>().Use<FizzRule>();
                            x.For<IRule>().Use<BuzzRule>();
                            x.For<IFizzBuzzService>().Use<FizzBuzzService>();
                        });
            return ObjectFactory.Container;
        }
    }
}