using ReactiveUI;

namespace Probel.Reactor.Views
{
    /// <summary>
    /// Interaction logic for ContextView.xaml
    /// </summary>
    public partial class ContextView
    {
        #region Constructors

        public ContextView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel,
                vm => vm.Input,
                view => view._contextText.Text);

            this.BindCommand(ViewModel,
                vm => vm.GotoBackCommand,
                view => view._btnBack);
        }

        #endregion Constructors
    }
}