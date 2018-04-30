using Autofac;
using ToyRobotSimulator.CommonAppInterfaces;
using ToyRobotSimulator.CommonAppServices;
using ToyRobotSimulator.TextAppInterfaces;
using ToyRobotSimulator.TextAppServices;

namespace ToyRobotSimulator.ConsoleTextUI
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandTextExecutor>().As<ICommandTextExecutor>();
            builder.RegisterType<CommandTextValidator>().As<ICommandTextValidator>();
            builder.RegisterType<UserInteractionByTextService>().As<IUserInteractionByTextService>();
            builder.RegisterType<TextCommandControl>().AsSelf();
            builder.RegisterType<ToyRobot>().AsSelf();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var textCommanControl = scope.Resolve<TextCommandControl>();
                textCommanControl.Start();
            }
        }
    }
}
