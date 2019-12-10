using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBusinessLogic.AutoMapperSettings
{
    public static class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void ConfigureAtApplicationStart()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                var profiles = GetProfiles();
                foreach (var profile in profiles)
                {
                    cfg.AddProfile((Activator.CreateInstance(profile) as Profile));
                }
            });
            configuration.CompileMappings();
            mapper = configuration.CreateMapper();
        }

        private static IEnumerable<Type> GetProfiles()
        {
            //Automapper profiles class are read from BuisnessLayer class library , in that AutoMapperProfiles folder
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(f => f.FullName.Contains("CoreBusinessLogic"));
            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes().Where(type => type.GetConstructors().Any(c => c.GetParameters().Count() == 0)
                         && !type.IsAbstract && typeof(Profile).IsAssignableFrom(type)))
                    {
                        yield return type;
                    }
                }
                finally { }
            }
        }
    }
}
