using Probel.Reactor.Core;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;

namespace Probel.Reactor.ViewModels
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        #region Fields

        private readonly LibraryViewModel _libraryVm;
        private readonly Random _random = new Random();
        #endregion Fields

        #region Constructors

        public MainViewModel(
            LibraryViewModel libraryVm = null,
            ContextViewModel contextVm = null,
            RoutingState router = null)
        {
            _libraryVm = libraryVm ?? Locator.Current.GetService<LibraryViewModel>();

            Router = router ?? Locator.Current.GetService<RoutingState>(RoutedViewHosts.Main);

            GotoLibrary = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_libraryVm));
            SendStatus = ReactiveCommand.Create(() =>
            {
                var i = _random.Next(1, 256);
                MessageBus.Current.SendMessage(new UiStatus($"Hello world {i}"));
            });
        }

        #endregion Constructors

        #region Properties

        public ReactiveCommand<Unit, IRoutableViewModel> GotoLibrary { get; }

        public RoutingState Router { get; private set; }
        public ReactiveCommand<Unit, Unit> SendStatus { get; }

        #endregion Properties
    }
}