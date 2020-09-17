using Probel.Reactor.ViewModels;
using ReactiveUI;
using Splat;
using System.Reactive.Disposables;

namespace Probel.Reactor.Views
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView 
    {
        #region Constructors

        public LibraryView()
        {
            InitializeComponent();

            ViewModel = Locator.Current.GetService<LibraryViewModel>();
            DataContext = ViewModel;

            this.WhenActivated(disposable =>
            {
                this.Bind(
                    ViewModel,
                    vm => vm.Criteria,
                    view => view._searchCriteria.Text)
                .DisposeWith(disposable);

                this.Bind(
                    ViewModel,
                    vm => vm.SelectedBook,
                    view => view._searchResults.SelectedItem)
                .DisposeWith(disposable);

                this.OneWayBind(
                    ViewModel,
                    vm => vm.Result,
                    view => view._searchResults.ItemsSource)
                .DisposeWith(disposable);

                this.OneWayBind(
                    ViewModel,
                    vm => vm.HasNoResult,
                    view => view._noResult.Visibility)
                .DisposeWith(disposable);
            });
        }

        #endregion Constructors
    }
}