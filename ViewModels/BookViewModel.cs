using Probel.Reactor.Core;
using ReactiveUI;
using Splat;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Probel.Reactor.ViewModels
{
    public class BookViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Fields

        private readonly ContextViewModel _contextVm;
        private readonly RoutingState _router;

        #endregion Fields

        #region Constructors

        public BookViewModel(ContextViewModel vm = null, RoutingState router = null)
        {
            _contextVm = vm ?? Locator.Current.GetService<ContextViewModel>();
            _router = router ?? Locator.Current.GetService<RoutingState>(RoutedViewHosts.Library);

            GotoContext = ReactiveCommand.CreateFromTask(GotoContextImpl);
        }

        #endregion Constructors

        #region Properties

        public string Author { get; set; }

        public ReactiveCommand<Unit, Unit> GotoContext { get; }

        public IScreen HostScreen { get; set; }
        public string Title { get; set; }
        public string UrlPathSegment => "Book";

        #endregion Properties

        #region Methods

        private async Task GotoContextImpl()
        {
            await Task.Delay(600);
            _contextVm.Input = $"book: {Author} -- {Title}";

            var doContinue = await Interactions.YesNo.Handle("Do you want to continue?");

            if (doContinue) { await _router.Navigate.Execute(_contextVm); }
        }

        #endregion Methods
    }
}