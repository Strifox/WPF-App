using Autofac;
using Monster.DataAccess;
using Monster.UI.Data;
using Monster.UI.View;
using Monster.UI.ViewModel;

namespace Monster.UI.Startup
{
    public class Bootstrapper
    {
  
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AccountContext>().AsSelf();

            builder.RegisterType<DetailsViewModel>().AsSelf();
            builder.RegisterType<DetailsWindow>().AsSelf();
            builder.RegisterType<NoteDataService>().As<INoteDataService>();

            return builder.Build();
        }
    }
}
