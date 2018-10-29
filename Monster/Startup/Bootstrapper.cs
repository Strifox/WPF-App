﻿using Autofac;
using Monster.DataAccess;
using Monster.UI.Data;
using Monster.UI.ViewModel;
using Monster.View;

namespace Monster.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountContext>().AsSelf();
            builder.RegisterType<DetailsWindow>().AsSelf();
            builder.RegisterType<DetailsViewModel>().AsSelf();
            builder.RegisterType<NoteDataService>().As<INoteDataService>();

            return builder.Build();
        }
    }
}
