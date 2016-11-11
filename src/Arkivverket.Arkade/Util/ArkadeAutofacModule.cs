using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Identify;
using Arkivverket.Arkade.Logging;
using Arkivverket.Arkade.Tests;
using Arkivverket.Arkade.Tests.Noark5;
using Autofac;

namespace Arkivverket.Arkade.Util
{
    public class ArkadeAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TarCompressionUtility>().As<ICompressionUtility>();
            builder.RegisterType<TestSessionFactory>().AsSelf();
            builder.RegisterType<ArchiveIdentifier>().As<IArchiveIdentifier>();
            builder.RegisterType<TestEngine>().AsSelf().SingleInstance();
            builder.RegisterType<ArchiveContentReader>().As<IArchiveContentReader>();
            builder.RegisterType<TestProvider>().As<ITestProvider>();
            builder.RegisterType<StatusEventHandler>().As<IStatusEventHandler>().SingleInstance();
            builder.RegisterType<Noark5TestProvider>().AsSelf();
        }
    }
}
