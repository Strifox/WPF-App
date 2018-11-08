using Autofac;
using Monster.DataAccess;
using Monster.UI.Data;
using Monster.UI.View;
using Monster.UI.ViewModel;
using System.Windows;

namespace Monster.UI.Startup
{
    public class Bootstrapper
    {
  
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AccountContext>().AsSelf();

            builder.RegisterType<NoteViewModel>().AsSelf();
            builder.RegisterType<NoteWindow>().AsSelf();

            builder.RegisterType<AccountViewModel>().AsSelf();
            builder.RegisterType<AccountWindow>().AsSelf();

            builder.RegisterType<AccountDataService>().As<IAccountDataService>();
            builder.RegisterType<NoteDataService>().As<INoteDataService>();

            return builder.Build();
        }
    }
}
