using Probel.Reactor.ViewModels;
using ReactiveUI;
using Splat;
using System.Reactive.Disposables;

namespace Probel.Reactor.Views
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView
    {
        #region Constructors

        public BookView()
        {
            InitializeComponent();

            ViewModel = Locator.Current.GetService<BookViewModel>();
            DataContext = ViewModel;

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(
                    ViewModel,
                    vm => vm.Title,
                    view => view._title.Text)
                .DisposeWith(disposable);

                this.OneWayBind(
                    ViewModel,
                    vm => vm.Author,
                    view => view._author.Text)
                .DisposeWith(disposable);

                this.BindCommand(ViewModel,
                    vm => vm.GotoContext,
                    view => view._btnShowContext)
                .DisposeWith(disposable);
                
            });
        }

        #endregion Constructors
    }
}