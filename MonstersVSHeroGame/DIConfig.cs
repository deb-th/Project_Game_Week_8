using Microsoft.Extensions.DependencyInjection;
using MonstersVSHeroGame.ADORepository;
using MonstersVSHeroGame.Core.Interfaces;
using MonstersVSHeroGame.MockRepository;
using MonstersVSHeroGame.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame
{
    public class DIConfig
    {
        public static ServiceProvider Config()
        {
            return new ServiceCollection()

                //aggiungo i miei servizi
                .AddScoped<HeroService>()
                .AddScoped<GiocatoreService>()
                .AddScoped<ArmaService>()
                .AddScoped<MostroService>()
                .AddScoped<ClasseService>()
                .AddScoped<LevelService>()

            #region Mock
                //per utilizzare il Mock
                //.AddScoped<IHeroRepository, MockHeroRepository>()
                //.AddScoped<IMostroRepository, MockMostroRepository>()
                //.AddScoped<IGiocatoreRepository, MockGiocatoreRepository>()
                //.AddScoped<IArmaRepository, MockArmaRepository>()
                //.AddScoped<ILevelRepository, MockLevelRepository>()
                //.AddScoped<IClasseRepository, MockClasseRepository>()
            #endregion

            #region ADO
                //per utilizzare il ADO
                .AddTransient<IHeroRepository, ADOHeroRepository>()
                .AddTransient<IMostroRepository, ADOMostroRepository>()
                .AddTransient<IGiocatoreRepository, ADOGiocatoreRepository>()
                .AddTransient<IArmaRepository, ADOArmaRepository>()
                .AddTransient<ILevelRepository, ADOLevelRepository>()
                .AddTransient<IClasseRepository, ADOClasseRepository>()
            #endregion

                //costruzione del provider generico dei servizi
                .BuildServiceProvider();
        }
    }
}