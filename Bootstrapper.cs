using AutoMapper;
using Probel.Reactor.Core;
using Probel.Reactor.Models;
using Probel.Reactor.ViewModels;
using ReactiveUI;
using Splat;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Probel.Reactor
{
    public static class RoutedViewHosts
    {
        #region Fields

        internal const string Library = nameof(Library);
        public const string Main = nameof(Main);

        #endregion Fields
    }

    public class Bootstrapper
    {
        #region Methods

        private static void RegisterAutoMapper()
        {
            var config = new MapperConfiguration(c =>
             {
                 c.CreateMap<BookModel, BookViewModel>();
             });
            Locator.CurrentMutable.Register(() => config.CreateMapper());
        }

        private static void RegisterInteractions()
        {
            Interactions.YesNo.RegisterHandler(i =>
            {
                i.SetOutput(MessageBox.Show(i.Input, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);
            });
        }

        private static void RegisterServices()
        {
            Locator.CurrentMutable.Register<ILibraryService>(() => new LibraryService());

            Locator.CurrentMutable.RegisterLazySingleton(() => new RoutingState(), RoutedViewHosts.Main);
            Locator.CurrentMutable.RegisterLazySingleton(() => new RoutingState(), RoutedViewHosts.Library);            
        }

        private static void RegisterViewModels()
        {
            var l = Locator.CurrentMutable;
            l.Register(() => new LibraryViewModel());
            l.Register(() => new MainViewModel());
            l.Register(() => new ContextViewModel());
        }

        public static void Initialise()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

            RegisterViewModels();

            RegisterServices();

            RegisterAutoMapper();

            RegisterInteractions();
        }

        #endregion Methods
    }
}