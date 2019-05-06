using Autofac;
using Bowling.Application.Services;
using Bowling.Infrastructure.Factories;
using Bowling.Infrastructure.FileAccess;
using Bowling.Infrastructure.Wrappers;

namespace Bowling.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StreamWriterWrapper>().As<IStreamWriter>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<StreamWriterFactory>().As<IFactory<string, IStreamWriter>>();
        }
    }
}
