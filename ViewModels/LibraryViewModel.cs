using Probel.Reactor.Core;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Probel.Reactor.ViewModels
{
    public class LibraryViewModel : ReactiveObject, IRoutableViewModel, IScreen
    {
        #region Fields

        private readonly ObservableAsPropertyHelper<IEnumerable<BookViewModel>> _result;
        private readonly ILibraryService _service;
        private string _criteria;
        private ObservableAsPropertyHelper<bool> _hasNoResult;
        private bool _isBusy;

        private BookViewModel _selectedBook;

        #endregion Fields

        #region Constructors

        public LibraryViewModel(ILibraryService service = null, RoutingState router = null)
        {
            Router = router ?? Locator.Current.GetService<RoutingState>(RoutedViewHosts.Library);
            _service = service ?? Locator.Current.GetService<ILibraryService>();

            _result = this
                .WhenAnyValue(x => x.Criteria)
                .Throttle(TimeSpan.FromMilliseconds(150))
                .Select(x => x?.Trim())
                .DistinctUntilChanged()
                .SelectMany(SearchBookAsync)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.Result);

            _hasNoResult = this
                .WhenAnyValue(x => x.Result)
                .Select(x => !(x?.Any() ?? false))
                .ToProperty(this, x => x.HasNoResult);

            this.WhenAnyValue(x => x.SelectedBook)
                .Where(x => x != null)
                .Subscribe(ViewModels =>
                {
                    Debug.WriteLine($"Changed book selection. {SelectedBook.Author} -- {SelectedBook.Title}");
                    Router.Navigate.Execute(SelectedBook);
                });
        }

        #endregion ConstructorsWo

        #region Properties

        public string Criteria
        {
            get => _criteria;
            set => this.RaiseAndSetIfChanged(ref _criteria, value);
        }

        public bool HasNoResult => _hasNoResult.Value;

        public IScreen HostScreen { get; protected set; }

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public IEnumerable<BookViewModel> Result => _result.Value;

        public BookViewModel SelectedBook
        {
            get => _selectedBook;
            set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
        }

        public string UrlPathSegment => "library";

        #endregion Properties

        #region Methods

        private async Task<IEnumerable<BookViewModel>> SearchBookAsync(string criteria)
        {
            var result = await _service.SearchBookAsync(criteria);
            var models = result.AsViewModel();
            return models;
        }

        public RoutingState Router { get; }

        #endregion Methods
    }
}