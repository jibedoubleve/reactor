using Probel.Reactor.Core;
using Probel.Reactor.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Probel.Reactor.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        #region Constructors

        public MainView()
        {
            InitializeComponent();

            ViewModel = Locator.Current.GetService<MainViewModel>();
            DataContext = ViewModel;

            this.WhenActivated(disposable =>
            {
                this.BindCommand(ViewModel, vm => vm.GotoLibrary, view => view._gotoLibrary).DisposeWith(disposable);
                this.BindCommand(ViewModel, vm => vm.SendStatus, view => view._sendStatus).DisposeWith(disposable);

                MessageBus.Current.Listen<UiStatus>().Subscribe(x =>
                {
                    _status.Content = x.Message;
                    _timeStamp.Content = x.TimeStamp.ToString();
                }).DisposeWith(disposable);
            });
        }

        #endregion Constructors
    }
}