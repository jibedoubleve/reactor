using ReactiveUI;
using Probel.Reactor.Core;
using Splat;
using System.Reflection;
using System.Windows;

namespace Probel.Reactor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            Bootstrapper.Initialise();
        }

        #endregion Constructors
    }
}