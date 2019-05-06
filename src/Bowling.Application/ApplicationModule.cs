using Autofac;
using Bowling.Application.Services;
using Bowling.Application.UseCases;
using Bowling.Domain.Entities;

namespace Bowling.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetBowlerScoreUseCase>().As<IRequestHandler<string, Score>>();
            builder.RegisterType<SaveBowlerScoreUseCase>().As<IRequestHandler<Score, bool>>();
            builder.RegisterType<CalculateScoreService>().As<ICalculateScoreService>();
        }
    }
}
