using Autofac;
using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.AppServices;
using ToyRobotSimulator.CommonAppInterfaces;
using ToyRobotSimulator.CommonAppServices;

namespace ToyRobotSimulator.ConsoleUI
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandExecutor>().As<ICommandExecutor>();
            builder.RegisterType<CommandTextValidator>().As<ICommandTextValidator>();
            builder.RegisterType<UserInteractionService>().As<IUserInteractionService>().InstancePerLifetimeScope(); // Instance of UserIteractionService is shared within a single ILifetimeScope
            builder.RegisterType<CommandControl>().AsSelf();
            builder.RegisterType<ToyRobot>().AsSelf();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var commanControl = scope.Resolve<CommandControl>();
                commanControl.Start();
            }
        }
    }
}

