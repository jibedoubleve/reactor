using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace Probel.Reactor.ViewModels
{
    public class ContextViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Fields

        private string _input;

        #endregion Fields

        public ContextViewModel(RoutingState router = null)
        {
            router ??= Locator.Current.GetService<RoutingState>(RoutedViewHosts.Library);
            GotoBackCommand = ReactiveCommand.CreateFromObservable(() => router.NavigateBack.Execute());
        }

        private Task<Unit> GotoBackImpl()
        {
            throw new NotImplementedException();
        }
        #region Properties

        public IScreen HostScreen
        {
            get; protected set;
        }

        public string Input
        {
            get => _input;
            set => this.RaiseAndSetIfChanged(ref _input, value);
        }

        public string UrlPathSegment => "context";

        public ReactiveCommand<Unit, Unit> GotoBackCommand { get; }
        #endregion Properties
    }
}