using Probel.Reactor.ViewModels;
using ReactiveUI;
using Splat;
using System.Reactive;

namespace Probel.Reactor.Commands
{
    public class NavigationCommand
    {
        #region Properties

        public ReactiveCommand<Unit, IRoutableViewModel> Command { get; set; }
        public string Label { get; private set; }

        #endregion Properties
    }

    public class NavigationCommands
    {
        #region Fields

        private static RoutingState _router;

        #endregion Fields

        #region Constructors

        public NavigationCommands(RoutingState router = null, LibraryViewModel libraryVm = null)
        {
            _router = router ?? Locator.Current.GetService<RoutingState>();
            libraryVm ??= Locator.Current.GetService<LibraryViewModel>();

            GotoLibrary = ReactiveCommand.CreateFromObservable(() => _router.Navigate.Execute(libraryVm));
        }

        #endregion Constructors

        #region Properties

        public ReactiveCommand<Unit, IRoutableViewModel> GotoLibrary { get; }

        #endregion Properties
    }
}