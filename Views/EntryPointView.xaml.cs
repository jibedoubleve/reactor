using MahApps.Metro.Controls;

namespace Probel.Reactor.Views
{
    /// <summary>
    /// Interaction logic for EntryPointView.xaml
    /// </summary>
    public partial class EntryPointView
    {
        #region Constructors

        public EntryPointView()
        {
            InitializeComponent();

            _findBook.Tag = new MainView();
        }

        #endregion Constructors

        #region Methods

        private void OnHamburgerMenuItemClick(object sender, ItemClickEventArgs args)
        {
            if (args?.ClickedItem is HamburgerMenuIconItem item)
            {
                _hamburgerMenu.Content = item.Tag;
            }
        }

        #endregion Methods
    }
}